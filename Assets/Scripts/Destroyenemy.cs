using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyenemy : MonoBehaviour
{
    public int noofhits;
   // public GameObject bullet;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            noofhits--;
            if (noofhits <= 0)
            {
                Destroy(gameObject);
            }
        }

        //Destroy(collision.gameObject);
    }
}
