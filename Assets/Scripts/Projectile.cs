using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Projectile : MonoBehaviour
{
    public string fire;
    public int no_of_bullets;
    //public GameObject bullet;
    public Transform cannon, head;
    public GameObject Muzzleeffect;
    public GameObject obj;
    public float force = 1000f;
    public float firerate;
    private float nextfirerate = 0f;
    //bool hasshoot = false;
    //public GameObject system;
    void Update()
    {
        
        if (Input.GetButton("Fire1") && no_of_bullets>0 && Time.time>=nextfirerate)
        {
            nextfirerate = Time.time + 1f / firerate;
            GameObject proj = Instantiate(obj, transform.position, cannon.rotation);
            FindObjectOfType<AudioManager>().Play(fire);
            GameObject effectmuzzle = Instantiate(Muzzleeffect, transform.position, transform.rotation);
            //hasshoot = true;

            Destroy(effectmuzzle, 1f);
            //Invoke("Stop", 3f);
            
            proj.GetComponent<Rigidbody>().AddRelativeForce(obj.transform.forward*force, ForceMode.Impulse);
            no_of_bullets--;
            if (no_of_bullets == 0)
            {
                Exit();
            }
        }
        
           
    }

    /*void Stop()
    {
        FindObjectOfType<AudioManager>().Stop();
    }*/
    void Exit()
    {
        Debug.Log("No bullets left");
    }
    
}
