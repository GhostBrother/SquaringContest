using UnityEngine;
using System.Collections;

public class Pistol : weapon {

    public Pistol() 
    {
        shotSpeed = 50;
        range = 1.5f;
        shotPattern = new SingleShot();
    }
    public override void modifyArt(GameObject bullet)
    {
        bullet.GetComponent<SpriteRenderer>().sprite = attackArtwork;
        base.modifyArt(bullet);
    }
    public override void modiftySpeed(GameObject bullet)
    {
        bullet.GetComponent<Projectile>().modifyBulletSpeed(shotSpeed);
    }

    public override void setDeathTime(GameObject bullet)
    {
        bullet.GetComponent<Projectile>().setDeathTime(range);
    }

    public override void setSoundToTrigger(GameObject bullet)
    {

    }

}
