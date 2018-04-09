using UnityEngine;
using System.Collections;

public class FlagSpawner : SpawnerKind {

    GameObject Flag;
    Vector3 flagSpawnPoint;

    // Use this for initialization
    void Awake () {
        currentState = spawnStates.RESPAWNING;
        waitTimer = 10.0f;
        flagSpawnPoint = new Vector3(this.transform.position.x, this.transform.position.y, -1);
    }

    public void requestFlag(GameObject FlagIn)
    {
        if (Flag == null)
        {
            Flag = (GameObject)Instantiate(FlagIn, flagSpawnPoint, Quaternion.identity); //  new Vector3 (this.transform.position.x, this.transform.position.y, 0)
            Flag.GetComponent<Flag>().setHome(flagSpawnPoint);
            Debug.Log("Another Flag is built");
        }
        else
        {
            Flag.transform.position = flagSpawnPoint;
            Flag.GetComponent<Flag>().setHome(flagSpawnPoint);
            Flag.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( Flag.activeInHierarchy != false ) //Flag != null ||
        {
            
           if (collision.tag == "Player") // again, I want away with the tag system for the real guy. 
            {  
                if (collision.GetComponent<Player>().primaryWeapon.GetComponent<Flag>() != null && collision.GetComponent<Player>().primaryWeapon.GetComponent<Flag>().whatColor() != Flag.GetComponent<Flag>().whatColor())
                {
                    GameManager.instance.UpdateScore(Flag.GetComponent<Flag>().whatColor());
                    collision.GetComponent<Player>().primaryWeapon.SetActive(false);
                    collision.GetComponent<Player>().primaryWeapon = collision.GetComponent<Player>().backupCQC;
                    setCooldown();
                }
                else if ((int)collision.GetComponent<Player>().scanForTeam() != (int)Flag.GetComponent<Flag>().whatColor() && collision.GetComponent<Player>().primaryWeapon.GetComponent<Flag>() == null)
                {
                    //collision.GetComponent<Player>().pickUpWeapon(Flag);
                    currentState = spawnStates.RESPAWNING;
                }
                   
            }
        }
    }

    public override void Activate(float timeToSet)
    {
        if (timeToSet <= 0)
        {
            GameManager.instance.resetFlag();// need help on fixing this. Not only is it a singleton, but it makes a circle. 
        }
    }


    // end of game flag revoker

    public void getRidOfFlag()
    {
        if (Flag != null)
        {
            Flag.GetComponent<Flag>().flagGoesAway();
            Flag.SetActive(false);
        }
        
    }

}
