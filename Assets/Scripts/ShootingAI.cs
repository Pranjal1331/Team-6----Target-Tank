using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    Transform player;
    public string sound;
    public Transform head, barrel;
    public GameObject projectile;
    GameObject clone;
    public GameObject effect;

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
        clone = Instantiate(projectile, barrel.position, head.rotation);
        GameObject eff = Instantiate(effect, barrel.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * force, ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play(sound);
        Destroy(eff, 1f);

    }

}
