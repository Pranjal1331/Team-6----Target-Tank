using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int no_of_bullets;
    public GameObject obj;
    public float force = 1000f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && no_of_bullets>0)
        {
            GameObject proj = Instantiate(obj, transform.position, transform.rotation);
            proj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, force));
            no_of_bullets--;
            if (no_of_bullets == 0)
            {
                Exit();
            }
        }
        
           
    }
    void Exit()
    {
        Debug.Log("No bullets left");
    }
    
}
