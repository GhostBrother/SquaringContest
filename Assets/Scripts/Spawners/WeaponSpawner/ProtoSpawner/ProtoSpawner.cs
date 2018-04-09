using UnityEngine;
using System.Collections;


public class ProtoSpawner : SpawnerKind { 

    GameObject assignedWeapon;

 

	// Use this for initialization
	void Start () {
        waitTimer = 5.0f;
        currentState = spawnStates.RESPAWNING;
        
	}

    public void requestWeapon(GameObject weaponIn)
    {
        assignedWeapon = weaponIn;
        assignedWeapon.SetActive(true);
        assignedWeapon.transform.position = this.transform.position;
    }

    public GameObject ReturnWeapon(GameObject weaponToReturn)
    {
        weaponToReturn.SetActive(false);
        return weaponToReturn;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (assignedWeapon != null)
        {
            if (collision.tag == "Player" && !collision.GetComponent<Player>().primaryWeapon.GetComponent<Flag>()) // again, I want away with the tag system for the real guy. also this check is a little wier 
            {
                GameObject DiscardedWeapon = collision.GetComponent<Player>().pickUpWeapon(assignedWeapon);
                ReturnWeapon(DiscardedWeapon);
                unshow(assignedWeapon);
                assignedWeapon = null;
                setCooldown();
            }
        }
    }

   

    private void unshow(GameObject collectedWeapon)
    {
        collectedWeapon.SetActive(false);
    }

    public override void Activate(float timeToSet)
    {
        if (timeToSet <= 0)
        {
            currentState = spawnStates.RESPAWNING;
        }
    }
}
