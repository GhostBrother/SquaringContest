using UnityEngine;
using System.Collections;
using System;

public interface iShotPattern {

    void CastShot(Vector2 direction, Vector2 position, GameObject bulletToMake);
}

public class SingleShot : MonoBehaviour, iShotPattern
{

    public void CastShot(Vector2 direction, Vector2 position , GameObject bulletToMake)
    {
        
        bulletToMake.GetComponent<Projectile>().modifyDirectionOfTravel(addNoise(direction));
        bulletToMake.transform.position = position + direction * (1.1f);
        bulletToMake.SetActive(true);
       // Instantiate(bulletToMake, position + direction, Quaternion.identity);
    }

    public Vector2 addNoise(Vector2 direction)
    {
        if (direction.x == 0)
        return direction + new Vector2(UnityEngine.Random.Range(-.5f,.5f), 0);

      else
            return direction + new Vector2(0,UnityEngine.Random.Range(-.5f, .5f));
    }
}

public class fiveShotSpread : MonoBehaviour, iShotPattern
{
    public void CastShot(Vector2 direction, Vector2 position, GameObject bulletToMake)
    {
        GameObject shotToMimic;
        for (int i = 0; i < 3; i++)
        {
            shotToMimic = ShotManager.Instance.giveShot();
            shotToMimic.GetComponent<Projectile>().modifyDirectionOfTravel(addNoise(direction));
            shotToMimic.transform.position = position + direction * (1.1f);
            bulletToMake.GetComponent<Projectile>().modifyDirectionOfTravel(addNoise(direction));
            bulletToMake.transform.position = position + direction * (1.1f);
            shotToMimic.GetComponent<Projectile>().modifyBulletSpeed(bulletToMake.GetComponent<Projectile>().readBulletSpeed());
            shotToMimic.GetComponent<Projectile>().setDeathTime(bulletToMake.GetComponent<Projectile>().readDeathTime());
            shotToMimic.GetComponent<Projectile>().setBulletTeamColor(bulletToMake.GetComponent<Projectile>().getBulletColor());
            shotToMimic.GetComponent<SpriteRenderer>().sprite = bulletToMake.GetComponent<SpriteRenderer>().sprite;
            shotToMimic.SetActive(true);
        }
    }

    public Vector2 addNoise(Vector2 direction)
    {
        if (direction.x == 0)
            return direction + new Vector2(UnityEngine.Random.Range(-.5f, .5f), 0);

        else
            return direction + new Vector2(0, UnityEngine.Random.Range(-.5f,.5f));
    }
}

public class Melee : MonoBehaviour, iShotPattern
{
    
    public void CastShot(Vector2 direction, Vector2 position, GameObject bulletToMake)
    {
        bulletToMake.GetComponent<Projectile>().modifyDirectionOfTravel(direction);
        bulletToMake.transform.position = position + direction * (1.5f);
        bulletToMake.transform.rotation = Quaternion.Euler(0, 0, directPunch(direction));
        bulletToMake.SetActive(true);
        //Instantiate(bulletToMake, position + direction, Quaternion.Euler( 0, 0, directPunch(direction)));
    }

    private float directPunch(Vector2 position)
    {
        if ( position.y == 1)
        return (position.x - 1) * 90;
        else
        return (position.x + 1) * 90;
    }
}
