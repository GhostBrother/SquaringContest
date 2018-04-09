using UnityEngine;
using System.Collections;


public abstract class weapon : MonoBehaviour {
    public Sprite weaponArtwork;
    public Sprite attackArtwork;
   // public ShotManager shotManager;
    protected int shotSpeed;
    protected float range;
    protected GameObject projectile;
    protected iShotPattern shotPattern;
    protected float reloadTime;
    protected float triggerSpeed;
    protected AudioSource soundToTrigger; 

    public void Shoot(Vector2 playerAim, Vector3 playerLoc, GameManager.Team coloredBullets)
    {
        projectile = ShotManager.Instance.giveShot();
        modiftySpeed(projectile);
        modifyArt(projectile);
        setDeathTime(projectile);
        projectile.GetComponent<Projectile>().setBulletTeamColor(coloredBullets);
        shotPattern.CastShot(playerAim,playerLoc, projectile);
    }

    public void Reload()
    {
        reloadTime -= Time.deltaTime;
    }

    public virtual void modifyArt(GameObject bullet)
    {

    }

    public virtual void modiftySpeed(GameObject bullet)
    {

    }

    public virtual void setDeathTime(GameObject bullet)
    {

    }

    public virtual void setSoundToTrigger(GameObject bullet)
    {

    }


}
