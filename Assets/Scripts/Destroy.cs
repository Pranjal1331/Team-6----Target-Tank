using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject collider1;
    //public GameObject collider2;
    public float life = 5f;
   // public int enemylife;
    //public int damage;
    public void OnCollisionEnter(Collision obj)
    {
        if (obj.transform.tag == "Obstacle")
        {   

            Destroy(collider1);
            
            
        }
        else if (obj.transform.tag == "Ground")
            Destroy(collider1, 0.5f);


        
        
    }

    
    
}
