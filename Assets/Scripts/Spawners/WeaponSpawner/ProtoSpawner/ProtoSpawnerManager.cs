using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProtoSpawnerManager : MonoBehaviour {
    public ProtoSpawner[] WeaponSpawnersInGame;
    public FlagSpawner[] RedSpawners;
    public FlagSpawner[] BlueSpawners;
    public PlayerSpawner[] redPlayerSpawner;
    public PlayerSpawner[] bluePlayerSpawner;
    public GameObject[] weaponsInGame;
    public GameObject RedFlag;
    public GameObject BlueFlag;
    public enum flagColor { RED, BLUE, GREEN, YELLOW }; // dont really like this being here
    protected Queue<GameObject> deadPile;
    // Use this for initialization
    void Start () {
        deadPile = new Queue<GameObject>();
        populateDeadPile();
        checkFlagSpawners();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (ProtoSpawner spawn in WeaponSpawnersInGame)
        {
            if (spawn.accessCurrentState() == ProtoSpawner.spawnStates.RESPAWNING)
            {
                spawn.requestWeapon(grabWeapon());
                spawn.mutateCurrentState(ProtoSpawner.spawnStates.LOADED);
            }
        }

	}
    // Flag Things
    public void checkFlagSpawners()  
    {

        foreach (FlagSpawner RSpawn in RedSpawners)
        {
            if (RSpawn.accessCurrentState() != SpawnerKind.spawnStates.RESPAWNING)
                break;

              spawnFlag(flagColor.RED); // switch to red blue enum? also cool if I have more than 2 teams.
        }

        foreach (FlagSpawner BSpawn in BlueSpawners)
        {
            if (BSpawn.accessCurrentState() != SpawnerKind.spawnStates.RESPAWNING)
                break;

            spawnFlag(flagColor.BLUE);
        }
    }


    public void spawnFlag(flagColor colorOfFlag) 
    {
        FlagSpawner spawner = null;
        if (colorOfFlag == flagColor.RED)
        {
            spawner = RedSpawners[Random.Range(0, RedSpawners.Length)];
            RedFlag.GetComponent<Flag>().changeFlagsColor(flagColor.RED);
            spawner.requestFlag(RedFlag);
        }
         if (colorOfFlag == flagColor.BLUE)
        {
            spawner = BlueSpawners[Random.Range(0, BlueSpawners.Length)];
            BlueFlag.GetComponent<Flag>().changeFlagsColor(flagColor.BLUE);
            spawner.requestFlag(BlueFlag);
            
        }
        spawner.mutateCurrentState(SpawnerKind.spawnStates.LOADED);
    }
    

    // end game flag thing
    public void revokeFlags()
    {
        foreach (FlagSpawner RSpawn in RedSpawners)
        {
            RSpawn.getRidOfFlag(); 
        }

        foreach (FlagSpawner BSpawn in BlueSpawners)
        {
            BSpawn.getRidOfFlag(); 
        }
    }




    //weapon things
    public GameObject grabWeapon()
    {
        GameObject objectTosend = deadPile.Dequeue();
        deadPile.Enqueue(objectTosend);
        return objectTosend;
    }


    public void populateDeadPile()
    {
        for (int i = 0; i < 20; i++)
        {
            deadPile.Enqueue((GameObject)Instantiate(LoadWeaponsIntoPool(), this.transform.position, Quaternion.identity));  
        }
        foreach (GameObject go in deadPile)
        {
            go.SetActive(false);
        }
    }
    private GameObject LoadWeaponsIntoPool()
    {
        return weaponsInGame[rollFor(0, weaponsInGame.Length)];
    }

    //playerThings

    public void sortDeadPlayer(Player playerToSort)
    {
        resetPlayerWeapon(playerToSort);

        if (playerToSort.scanForTeam() == GameManager.Team.RED)
        {
            redPlayerSpawner[rollFor(0, redPlayerSpawner.Length)].AddToList(playerToSort);
        }

        if (playerToSort.scanForTeam() == GameManager.Team.BLUE)
        {
            bluePlayerSpawner[rollFor(0, bluePlayerSpawner.Length)].AddToList(playerToSort);
        }
    }

    private void resetPlayerWeapon(Player playerToSort)
    {
        playerToSort.primaryWeapon = weaponsInGame[1]; // should rename this to an enmum of wepons someday.
    }

    
   

    private int rollFor(int min, int max)
    {
        return Random.Range(min, max);
    }



}

