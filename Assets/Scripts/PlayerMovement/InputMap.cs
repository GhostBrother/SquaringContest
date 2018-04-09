using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputMap : MonoBehaviour {

    public Dictionary<KeyCode, string> keysPressed, keysReleased;

    public InputMap()
    {
        keysPressed = new Dictionary<KeyCode, string>();
        keysReleased = new Dictionary<KeyCode, string>();
        this.Initalize();
    }

    public virtual void Initalize()
    {

        //Released keys Map May load from text file
   
        keysPressed.Add(KeyCode.W, "Move Up");
        keysPressed.Add(KeyCode.UpArrow, "Move Up");
        keysPressed.Add(KeyCode.S, "Move Down");
        keysPressed.Add(KeyCode.DownArrow, "Move Down");
        keysPressed.Add(KeyCode.A, "Move Left");
        keysPressed.Add(KeyCode.LeftArrow, "Move Left");
        keysPressed.Add(KeyCode.D, "Move Right");
        keysPressed.Add(KeyCode.RightArrow, "Move Right");
        keysPressed.Add(KeyCode.E, "Switch");
        keysPressed.Add(KeyCode.Space, "Roll");
        keysPressed.Add(KeyCode.Mouse0, "Shoot");
        keysPressed.Add(KeyCode.Q, "DEBUG");
       

        keysReleased.Add(KeyCode.W, "Move Up");
        keysReleased.Add(KeyCode.UpArrow, "Move Up");
        keysReleased.Add(KeyCode.S, "Move Down");
        keysReleased.Add(KeyCode.DownArrow, "Move Down");
        keysReleased.Add(KeyCode.A, "Move Left");
        keysReleased.Add(KeyCode.LeftArrow, "Move Left");
        keysReleased.Add(KeyCode.D, "Move Right");
        keysReleased.Add(KeyCode.RightArrow, "Move Right");
        keysReleased.Add(KeyCode.E, "Switch");
        keysReleased.Add(KeyCode.Space, "Roll");
        keysReleased.Add(KeyCode.Mouse0, "Shoot");
    }

   
}
