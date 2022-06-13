using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float life = 1f;
    private void Awake()
    {
        Destroy(gameObject, life);
 
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }*/
}
