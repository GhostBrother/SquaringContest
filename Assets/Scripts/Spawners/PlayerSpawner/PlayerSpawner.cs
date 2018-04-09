using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawner : SpawnerKind {

    private List<Player> playerWaitingForRespawn;
	// Use this for initialization
	void Start () {
        playerWaitingForRespawn = new List<Player>();
        waitTimer = 3.0f;
    }
	

    public void AddToList(Player deadPlayer)
    {
        playerWaitingForRespawn.Add(deadPlayer);
        setCooldown();
    }

    public override void Activate(float timeToSet)
    {
        if (timeToSet <= 0)
        {
            playerWaitingForRespawn[0].transform.position = this.transform.position;
            playerWaitingForRespawn[0].gameObject.SetActive(true);
           // p.pickUpWeapon(spawnerManager.weaponsInGame[1]); // HACK
            playerWaitingForRespawn[0].changeLifeState(Player.lifeState.OK);
            playerWaitingForRespawn.RemoveAt(0);

        }
    }
}
