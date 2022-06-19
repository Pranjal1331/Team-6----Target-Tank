using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootindAI : MonoBehaviour
{

    Transform player;
    public Transform head, barrel;
    public GameObject projectile;
    
    public float force;
    public float Firerate, nextfire;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        head.LookAt(player);

        if (Time.time >= nextfire)
        {
            nextfire = Time.time + 1f / Firerate;
            Shoot();

        }
    }

    void Shoot()
    {
       GameObject clone = Instantiate(projectile, barrel.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * force, ForceMode.Impulse);
        Destroy(clone, 5f);
    }

    
}
