//using UnityEngine;
//using System.Collections;

//public class bulletFactory : MonoBehaviour {

//    private static bulletFactory instance = null;
//    public Sprite[] allBulletsInGame = new Sprite[3];
//    public enum weaponTypes { PISTOL,SHOTGUN,MELEE}
//    public GameObject projectileToBuild;
//    private static readonly object padloc = new object();

//    public static bulletFactory Instance
//    {
//        get
//        {
//            lock (padloc)
//            {

//                if (instance == null)
//                {
//                    instance = new bulletFactory();
//                }
//                return instance;
//            }
//        }
//    }

//    public GameObject forgeBullet(weaponTypes typeToBuild)
//    {
//        switch(typeToBuild)
//        {
//            case weaponTypes.PISTOL:
//                {
//                    projectileToBuild.GetComponent<Projectile>().setShotAppearance(allBulletsInGame[(int)typeToBuild]);
//                    return projectileToBuild;
//                }
//            case weaponTypes.SHOTGUN:
//                {
//                    projectileToBuild.GetComponent<Projectile>().setShotAppearance(allBulletsInGame[(int)typeToBuild]);
//                    return projectileToBuild;
//                }

//            case weaponTypes.MELEE:
//                {
//                    projectileToBuild.GetComponent<Projectile>().setShotAppearance(allBulletsInGame[(int)typeToBuild]);
//                    return projectileToBuild;
//                }

//            default:
//                {
//                    projectileToBuild.GetComponent<Projectile>().setShotAppearance(allBulletsInGame[(int)weaponTypes.PISTOL]);
//                    return projectileToBuild;
//                }
//        }
//    }


//}
