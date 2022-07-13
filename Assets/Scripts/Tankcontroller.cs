using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankcontroller : MonoBehaviour
{
    public Transform[] wheels;
    public WheelCollider[] wheelsCollider;
    Vector3 Pos, rotation;
    Quaternion Quad;
    public float Force, Rotspeed;
    public string sound;
    void Start()
    {
        rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = rotation;
        for (int i = 0; i < wheelsCollider.Length; i++)
        {
            wheelsCollider[i].GetWorldPose(out Pos, out Quad);
            wheels[i].position = Pos;
            wheels[i].rotation = Quad;
        }
        foreach (var wheelcoll in wheelsCollider)
        {   
            wheelcoll.motorTorque = Input.GetAxis("Vertical") * Force * Time.deltaTime;
           

        }
        
        rotation.y += Input.GetAxis("Horizontal") * Rotspeed;
        
        
    }
}
