using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCommandProcessor : MonoBehaviour
{

    InputMap input;
    public GameObject MoveableEntity;
    public GameObject DEBUGEntity;
    public List<GameObject> allGameObjects = new List<GameObject>();

    public PlayerCommandProcessor() : base()
    {
        input = new InputMap();
    }




    // Update is called once per frame
    public void Update()
    {
        //Check keys in keymap
        //Has Released Keys
        foreach (var item in input.keysPressed)
        {
            
            if (Input.GetKeyDown(item.Key))
            {
                Command command = null;
               // Debug.Log(string.Format("onReleasedKeyMap Key pressed {0}", item.Value.ToString())); //Log key to console
                
                switch (item.Value)
                {
                    case "Move Up":
                        //trigger Move Up command
                       
                        command = new MoveUp();
                        
                        break;
                    case "Move Down":
                       
                        command = new MoveDown();
                     
                        break;
                    case "Move Left":
 
                        command = new MoveLeft();
                        break;
                    case "Move Right":
                        command = new MoveRight();
                       
                        break;
                    case "Switch":
                        command = new SwitchWeapon();
                        break;
                    case "Roll":
                        command = new Roll();
                        break;
                    case "Shoot":
                        command = new Shoot();

                        break;
                    case "DEBUG":
                        GameObject temp;
                        temp = MoveableEntity;
                        MoveableEntity = DEBUGEntity;
                        DEBUGEntity = temp;
                        break;
                }

                    if (command != null)
                {
                    ActivateCommand(command);
                }
                

            }
           
            if (Input.GetKeyUp(item.Key) )
            {
                Command command = null;
               // Debug.Log(string.Format("onReleasedKeyMap Key released {0}", item.Value.ToString())); //Log key to console
                switch (item.Value)
                {
                    case "Move Up":
                        command = new WaitUp();
                        break;
                    case "Move Down":
                        command = new WaitDown();
                        break;
                    case "Move Left":
                        command = new WaitLeft();
                        break;
                    case "Move Right":
                        command = new WaitRight();
                        break;
                }
                if (command != null)
                ActivateCommand(command);
            }
           
                
        }
        
 
    }
    private void ActivateCommand(Command command)
    {
        command.execute(MoveableEntity);
    }

}
