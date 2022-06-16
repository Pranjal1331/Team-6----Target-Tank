using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject collider1;
    public float life = 10f;
    
    public void OnCollisionEnter(Collision obj)
    {
        if (obj.transform.tag == "Obstacle")
            Destroy(collider1, 1);
    }
    private void Delete()
    {
        Destroy(collider1, life);

    }

}
