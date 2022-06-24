using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    public Rigidbody RB3D;
  
    public float speed = 6f;
    bool left;
    bool right;
    bool forward;
    bool backward;
    public float force;
    public GameObject body;
    public float a_body;
    public float s_body;
    


    void FixedUpdate()
    {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);

        /*Vector3 position = new Vector3(horizontal, 0f, vertical).normalized;

        if (position.magnitude >= 0.1f)
        {   
            tankcontroller.Move(position * speed * Time.deltaTime);
        }
    }*/
        
        if (forward) RB3D.AddForce(0, 0, force * Time.deltaTime);
        else if (backward) RB3D.AddForce(0, 0, -force * Time.deltaTime);
       else if (left)
        {
            a_body += s_body * Time.deltaTime;
            a_body = Mathf.Clamp(a_body, 0 , 360);
            body.transform.localRotation = Quaternion.AngleAxis(a_body, Vector3.down);
            RB3D.AddForce(-force * Time.deltaTime, 0, 0);
        }
        else if (right)
        {
            a_body += s_body * Time.deltaTime;
            a_body = Mathf.Clamp(a_body, 0, 360);
            body.transform.localRotation = Quaternion.AngleAxis(a_body, Vector3.up);
            RB3D.AddForce(force * Time.deltaTime, 0, 0);
        }
    }
}
