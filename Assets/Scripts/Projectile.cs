using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public GameObject obj;
    public float force = 1000f;
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject proj = Instantiate(obj, transform.position, transform.rotation);
            proj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, force));
            
        }
        
           
    }
}
