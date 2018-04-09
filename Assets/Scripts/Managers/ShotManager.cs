using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotManager {

    
    private static ShotManager instance = null;
    private static Queue<GameObject> AllShots;

    private static readonly object padloc = new object();

    public static ShotManager Instance
    {
        get
        {
            lock (padloc)
            {

                if (instance == null)
                {
                    instance = new ShotManager();
                }
                return instance;
            }
        }
    }
   
        
  

    public void loadAllShots(GameObject ArguableBullet)
    {
        AllShots = new Queue<GameObject>();
        for (int i = 0; i < 50; i ++)
        {
            AllShots.Enqueue(GameObject.Instantiate(ArguableBullet));
        }
        foreach (GameObject gs in AllShots)
        {
            gs.SetActive(false);
        }
    }

    public GameObject giveShot()
    {
        GameObject shotToGive = AllShots.Dequeue();
        shotToGive.SetActive(true);
        AllShots.Enqueue(shotToGive);
        return shotToGive;
    }
}
