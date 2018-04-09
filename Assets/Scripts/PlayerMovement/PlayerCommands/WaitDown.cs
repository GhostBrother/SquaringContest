using UnityEngine;
using System.Collections;

public class WaitDown : Command
{
    public WaitDown() : base()
    {


    }

    public override void execute(GameObject gc)
    {


        ////Different Game Components may move differently check if the gc is a CommandPacMan
        var target = gc.GetComponent<Player>();
        if (target is Player)
        {
            target.WaitDown();
        }
        base.execute(gc);
    }
}

