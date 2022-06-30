using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject collider1;
    //public GameObject collider1;
    //public float radius;
    //public float explosionForce;
    public GameObject explosioneffect1;
    GameObject effect;
    //bool hasExploded = false;

    public void OnCollisionEnter(Collision obj)
    {
        if (obj.transform.tag == collider1.transform.tag)
        {
            effect = Instantiate(explosioneffect1, transform.position, transform.rotation);
            Destroy(obj.gameObject);
            Destroy(gameObject);
           
            //hasExploded = true;
            Destroy(effect, 1f);
        }
        else
        {
            Destroy(gameObject, 10f);
        }
   
    }

   /* void Explode()
    {

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        Destroy(gameObject);
        Destroy(explosioneffect);
    }*/



}
