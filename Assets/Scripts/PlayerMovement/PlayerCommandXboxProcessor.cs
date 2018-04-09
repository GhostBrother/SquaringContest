using UnityEngine;
using System.Collections;

public class PlayerCommandXboxProcessor : MonoBehaviour
{

    public GameObject p1MoveableEntity;
    public GameObject p2MoveableEntity;

    public PlayerCommandXboxProcessor() : base()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        Command p1command = null;
        Command p2command = null; 

        if (Input.GetAxis("Vertical") < -.25f)
        {
            p1command = new MoveUp();
            
            p1ActivateCommand(p1command);
            
        }
       
        if (Input.GetAxis("Vertical") > .25f)
        {
            p1command = new MoveDown();
            p1ActivateCommand(p1command);
        }
        if (Input.GetAxis("Horizontal") < -.25f)
        {
            p1command = new MoveLeft();
           p1ActivateCommand(p1command);
        }
        if (Input.GetAxis("Horizontal") > .25f)
        {
            p1command = new MoveRight();
            p1ActivateCommand(p1command);
        }
        if (Input.GetButtonDown("switch"))
        {
            p1command = new SwitchWeapon();
            p1ActivateCommand(p1command);
        }

        if (Input.GetButtonDown("Roll"))
        {
            p1command = new Roll();
            p1ActivateCommand(p1command);
        }

        if (Input.GetButtonDown("Shoot"))
        {
            p1command = new Shoot();
            p1ActivateCommand(p1command);
        }

        if (Input.GetAxis("Vertical") > -.75f && Input.GetAxis("Vertical") <= .25f)
        {
            p1command = new WaitUp();
            p1ActivateCommand(p1command);
        }

        if (Input.GetAxis("Vertical") >= -.25f && Input.GetAxis("Vertical") < .75f)
        {
            p1command = new WaitDown();
            p1ActivateCommand(p1command);
        }

        if (Input.GetAxis("Horizontal") > -.75f && Input.GetAxis("Horizontal") <= 25f)
        {
            p1command = new WaitLeft();
            p1ActivateCommand(p1command);
        }

        if (Input.GetAxis("Horizontal") >= -.25f && Input.GetAxis("Horizontal") < .75f)
        {
            p1command = new WaitRight();
            p1ActivateCommand(p1command);
        }


        //////////////////////////////////////P2 = aka, there has to be a better way...

        if (Input.GetAxis("VerticalP2") < -.25f)
        {
            p2command = new MoveUp();
            p2ActivateCommand(p2command);
        }

        if (Input.GetAxis("VerticalP2") > .25f)
        {
            p2command = new MoveDown();
            p2ActivateCommand(p2command);
        }
        if (Input.GetAxis("HorizontalP2") < -.25f)
        {
            p2command = new MoveLeft();
            p2ActivateCommand(p2command);
        }
        if (Input.GetAxis("HorizontalP2") > .25f)
        {
            p2command = new MoveRight();
            p2ActivateCommand(p2command);
        }
        if (Input.GetButtonDown("switchP2"))
        {
            p2command = new SwitchWeapon();
            p2ActivateCommand(p2command);
        }

        if (Input.GetButtonDown("RollP2"))
        {
            p2command = new Roll();
            p2ActivateCommand(p2command);
        }

        if (Input.GetButtonDown("ShootP2"))
        {
            p2command = new Shoot();
            p2ActivateCommand(p2command);
        }

        if (Input.GetAxis("VerticalP2") > -.75f && Input.GetAxis("VerticalP2") <= .25f)
        {
            p2command = new WaitUp();
            p2ActivateCommand(p2command);
        }

        if (Input.GetAxis("VerticalP2") >= -.25f && Input.GetAxis("VerticalP2") < .75f)
        {
            p2command = new WaitDown();
            p2ActivateCommand(p2command);
        }

        if (Input.GetAxis("HorizontalP2") > -.75f && Input.GetAxis("HorizontalP2") <= 25f)
        {
            p2command = new WaitLeft();
            p2ActivateCommand(p2command);
        }

        if (Input.GetAxis("HorizontalP2") >= -.25f && Input.GetAxis("HorizontalP2") < .75f)
        {
            p2command = new WaitRight();
            p2ActivateCommand(p2command);
        }
    }

    private void p1ActivateCommand(Command command)
    {
        command.execute(p1MoveableEntity);
        
    }

    private void p2ActivateCommand(Command command)
    {
        command.execute(p2MoveableEntity);
    }

}



