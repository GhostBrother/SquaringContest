using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float setRollCooldown;
    public float setHowLongTheRollTakes;
    private float rollTime;
    private float distanceOfRoll;
    private float rollCoolDown;
    private const byte fixedSpeed = 8;
    private GameManager.Team teamOn; 

    Vector2 directionOfTravel;
    Vector2 previousDirectionOfTravel;
    private Vector3 moveTranslation;
   
    public GameObject primaryWeapon; 
   // public GameObject secondaryWeapon;
    public GameObject backupCQC; 


    private enum rollStates { ROLLING, CANROLL, ROLLCOOLDOWN};
    private rollStates currentRollState;

    public enum lifeState { OK, RESPAWNING, ELIMINATED };
    private lifeState status;

    // Use this for initialization
    void Start () {
        primaryWeapon = Instantiate(primaryWeapon);
        primaryWeapon.GetComponent<SpriteRenderer>().enabled = false;
        backupCQC = Instantiate(backupCQC);
        backupCQC.GetComponent<SpriteRenderer>().enabled = false;   // need to find a new home for these, maybe in the game manager somewhere. 
        previousDirectionOfTravel = new Vector2(0, 1); 
        currentRollState = rollStates.CANROLL;
        status = lifeState.OK;
	}

    // Update is called once per frame
    void Update()
    {
        this.moveTranslation = new Vector3(this.directionOfTravel.x, this.directionOfTravel.y) * this.GetComponent<SpriteRenderer>().bounds.size.x;
        this.transform.position += new Vector3(this.moveTranslation.x, this.moveTranslation.y) * Time.deltaTime * fixedSpeed;

        if (directionOfTravel != Vector2.zero)  // only updates previous direction of travle when player moves
        {
            previousDirectionOfTravel = directionOfTravel;   // sets our previous Direction of travel equal to our latest non 0,0 direction of travel. 
        }

        if (currentRollState == rollStates.ROLLING) // Kinda neat functionality, I just don't like how this looks, help me out Jeff? 
        {
            Vector2 endMarker = this.transform.position + new Vector3(previousDirectionOfTravel.x, previousDirectionOfTravel.y);
            transform.position = Vector3.Lerp(this.transform.position, endMarker, .5f);
            rollTime -= Time.deltaTime;

            if (rollTime <= 0)
            {
                currentRollState = rollStates.ROLLCOOLDOWN;
                rollCoolDown = setRollCooldown;
            }
        }

        if (currentRollState == rollStates.ROLLCOOLDOWN)
        {
            rollCoolDown -= Time.deltaTime;
            if (rollCoolDown <= 0)
            {
                currentRollState = rollStates.CANROLL;
            }
        }

        primaryWeapon.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            if (collision.gameObject.GetComponent<Projectile>().getBulletColor() != teamOn)
            {
                this.gameObject.SetActive(false);
                status = lifeState.ELIMINATED;
            }
        }
    }

    public void changeTeamColor(GameManager.Team TeamColor)
    {
        teamOn = TeamColor;
    }

    public void MoveUp()
    {
        directionOfTravel.y = 1;
    }

    public void MoveDown()
    {
        directionOfTravel.y = -1;
    } 

    public void MoveRight()
    {
        directionOfTravel.x = 1;
    }

    public void MoveLeft()
    {
        directionOfTravel.x = - 1;
    }

    public void WaitRight()
    {
        if(directionOfTravel.x == 1)
        directionOfTravel.x = 0;
    }
    public void WaitLeft()
    {
        if (directionOfTravel.x == -1)
            directionOfTravel.x = 0;
    }

    public void WaitUp()
    {
        if (directionOfTravel.y == 1)
        directionOfTravel.y = 0; 
    }
    public void WaitDown()
    {
        if (directionOfTravel.y == -1) // All these conditional checks bother me so... must find alternative.
            directionOfTravel.y = 0;  // However, learning the capabilites of the command pattern through practice. pretty neat.
    }


    public void Roll()
    {
        if (currentRollState == rollStates.CANROLL)
        {
            rollTime = setHowLongTheRollTakes; //0.05f;
            distanceOfRoll = .025f; // TESTING ONLY, these will be rid of in favor of a designer friendly inspector public variable. 
            currentRollState = rollStates.ROLLING;  
        }
    }


    public GameObject pickUpWeapon(GameObject newWeapon)
    {
        GameObject temp = primaryWeapon;
        primaryWeapon = newWeapon;
        return temp;
    }

    public void dropWeapon()
    {
        primaryWeapon = null; 
    }


    public void SwitchWeapon()
    {
        GameObject temp = primaryWeapon;
       // primaryWeapon = secondaryWeapon;
        //secondaryWeapon = temp;
    }

    public void ShootCurrentWeapon()
    { 
        if (primaryWeapon == null)
        {
            primaryWeapon = backupCQC;
        }
        if ( currentRollState != rollStates.ROLLING && status != lifeState.RESPAWNING)
        {

           primaryWeapon.GetComponent<weapon>().Shoot(previousDirectionOfTravel, this.transform.position, teamOn);
        }
        
    }

    public lifeState playerIsAlive()
    {
        return status;
    }

    public void changeLifeState(lifeState inboundLifeState)
    {
        status = inboundLifeState;
    }

    public GameManager.Team scanForTeam()
    {
        return teamOn;
    }

}
