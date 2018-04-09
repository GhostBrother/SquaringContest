using UnityEngine;
using System.Collections;

public class Flag : weapon
{ 
    [SerializeField]
     ProtoSpawnerManager.flagColor thisFlagsColor;
    private Vector3 Home;
    public Flag()
    {
        shotSpeed = 5;
        range = 0.1f;
        shotPattern = new Melee();
    }

    private void OnTriggerEnter2D(Collider2D collision)  // This might be a little pricey for the the weapon alone... 
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if ((int)collision.gameObject.GetComponent<Player>().scanForTeam() != (int)thisFlagsColor)
            {
                collision.gameObject.GetComponent<Player>().primaryWeapon = this.gameObject;
            }
            else if ((int)collision.gameObject.GetComponent<Player>().scanForTeam() == (int)thisFlagsColor)
            {
                flagGoHome();
            }
        }
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

    public void changeFlagsColor(ProtoSpawnerManager.flagColor changeColor)
    {
        thisFlagsColor = changeColor;
    }

    public ProtoSpawnerManager.flagColor whatColor()
    {
        return thisFlagsColor;
    }

    public void setHome(Vector3 thisFlagsHome)
    {
        Home = thisFlagsHome;
    }

    private void flagGoHome()
    {
        this.transform.position = Home;
    }

    public void flagGoesAway()
    {
        this.gameObject.SetActive(false);
    }

}

