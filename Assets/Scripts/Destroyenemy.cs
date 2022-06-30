using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyenemy : MonoBehaviour
{
    public string destroyenemy;
    public Healthbar healthbar;
    public float enemyhealth;
    public float damage;
    public GameObject collider1;
    public GameObject explosioneffect1, explosioneffect2;
    GameObject effect;
   // public GameObject bullet;
    public void OnCollisionEnter(Collision collision)
    {
        //GameObject temp1 = collider1;
        
        if (collision.transform.tag == collider1.transform.tag)
        {
            effect = Instantiate(explosioneffect1, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(effect, 2f);

            enemyhealth-=damage;
            healthbar.sethealth(enemyhealth);
            if (enemyhealth == 0)
            {
                effect = Instantiate(explosioneffect2, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(effect, 2f);
                
                FindObjectOfType<AudioManager>().Play(destroyenemy);
                
            }
        }
        
        //Destroy(collision.gameObject);
    }
}
