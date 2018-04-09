using UnityEngine;
using System.Collections;

public class MoveLeft : Command
{
    public MoveLeft() : base()
    {


    }

    public override void execute(GameObject gc)
    {


        ////Different Game Components may move differently check if the gc is a CommandPacMan
        var target = gc.GetComponent<Player>();
        if (target is Player)
        {
            target.MoveLeft();
        }
        base.execute(gc);
    }
}

