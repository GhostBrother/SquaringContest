using UnityEngine;
using System.Collections;

public class MoveUp : Command
{
    public MoveUp() : base()
    {


    }

    public override void execute(GameObject gc)
    {


        ////Different Game Components may move differently check if the gc is a CommandPacMan
        var target = gc.GetComponent<Player>();
        if (target is Player)
        {
            target.MoveUp();
        }
        base.execute(gc);
    }
}

