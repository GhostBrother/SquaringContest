using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    
    [SerializeField]
    private Vector2 directionOfTravel;
    [SerializeField]
    float lifeSpan;
    private Vector3 moveTranslation;
    [SerializeField]
    protected int bulletSpeed;
    [SerializeField]
    private GameManager.Team colorOfBullet; 

    private void Update() 
    {
        this.moveTranslation = new Vector3(directionOfTravel.x,directionOfTravel.y) * this.GetComponent<SpriteRenderer>().bounds.size.x; 
        this.transform.position += new Vector3(this.moveTranslation.x, this.moveTranslation.y) * Time.deltaTime * bulletSpeed;
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
         if (collision.tag == "Wall") // want to do away with the tag system after prototype
        {
            this.gameObject.SetActive(false);
        }
    }

    public void modifyDirectionOfTravel(Vector2 newDirectionOfTravel)
    {
        directionOfTravel = newDirectionOfTravel;
    }

    public void modifyBulletSpeed(int newBulletSpeed)
    {
       bulletSpeed = newBulletSpeed;
    }

    public int readBulletSpeed()
    {
        return bulletSpeed;
    }
    public void setDeathTime(float deathTime)
    {
        lifeSpan = deathTime;
    }

    public float readDeathTime()
    {
        return lifeSpan;
    }

    public void setBulletTeamColor(GameManager.Team teamColorFiringShot)
    {
        colorOfBullet = teamColorFiringShot;
    }

    public GameManager.Team getBulletColor()
    {
        return colorOfBullet;
    }
}
