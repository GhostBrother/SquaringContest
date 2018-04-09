using UnityEngine;
using System.Collections;

public class Punch : weapon {

    // Use this for initialization
    public Punch()
    {
        shotSpeed = 5;
        range = 0.1f;
        shotPattern = new Melee();
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


}
