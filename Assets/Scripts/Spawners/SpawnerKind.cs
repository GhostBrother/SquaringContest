using UnityEngine;
using System.Collections;

public abstract class SpawnerKind : MonoBehaviour {

    protected float timeIn;
    protected float waitTimer;
    public enum spawnStates { LOADED, COOLDOWN, RESPAWNING };
    public spawnStates currentState; // make protected after debug.
    // Update is called once per frame
    void Update () {
        
	if (timeIn > 0)
        {
            timeIn -= Time.deltaTime;
            Activate(timeIn);
        }
	}

    //public virtual void SetTheClock(float timeToSet)
    //{
    //    timeIn = timeToSet;
    //}

    public virtual void Activate(float timeToSet)
    {
        Debug.Log("You reached me instead");
    }

    public spawnStates accessCurrentState()
    {
        return currentState;
    }

    public void mutateCurrentState(spawnStates transitionTo)
    {
        currentState = transitionTo;
    }
    protected void setCooldown()
    {
        timeIn = waitTimer;
        currentState = spawnStates.COOLDOWN;
       // SetTheClock(timeIn);
    }
}
