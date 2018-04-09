using UnityEngine;
using System.Collections;

public class ShotGun : weapon {

    public ShotGun()
    {
        shotSpeed = 50;
        range = .5f;
        shotPattern = new fiveShotSpread();
    }

    public override void modiftySpeed(GameObject bullet)
    {
        bullet.GetComponent<Projectile>().modifyBulletSpeed(shotSpeed);
    }

    public override void setDeathTime(GameObject bullet)
    {
        bullet.GetComponent<Projectile>().setDeathTime(range);
    }
    public override void modifyArt(GameObject bullet)
    {
        bullet.GetComponent<SpriteRenderer>().sprite = attackArtwork;
        base.modifyArt(bullet);
    }

   
}
