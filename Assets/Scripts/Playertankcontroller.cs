using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertankcontroller : MonoBehaviour
{
    private float Forwardinput;
    private float Rotationinput;
    public float Forwardspeed;
    public float Rotationspeed;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Forwardinput = Input.GetAxis("Vertical");
        Rotationinput = Input.GetAxis("Horizontal");
        Vector3 currposition = transform.position + (transform.forward * Forwardinput * Forwardspeed * Time.deltaTime);
        rb.MovePosition(currposition);
        Quaternion currrotation = transform.rotation * Quaternion.Euler(Vector3.up * (Rotationspeed * Rotationinput * Time.deltaTime));
        rb.MoveRotation(currrotation);

    }
}
