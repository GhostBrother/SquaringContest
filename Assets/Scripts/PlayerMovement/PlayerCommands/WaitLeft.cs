using UnityEngine;
using System.Collections;

public class WaitLeft : Command
{
    public WaitLeft() : base()
    {


    }

    public override void execute(GameObject gc)
    {


        ////Different Game Components may move differently check if the gc is a CommandPacMan
        var target = gc.GetComponent<Player>();
        if (target is Player)
        {
            target.WaitLeft();
        }
        base.execute(gc);
    }
}
