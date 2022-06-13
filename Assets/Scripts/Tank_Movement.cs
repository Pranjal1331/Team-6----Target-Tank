using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    public CharacterController tankcontroller;
    public float speed = 6f;

    void Start()
    {

    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 position = new Vector3(horizontal, 0f, vertical).normalized;

        if (position.magnitude >= 0.1f)
        {   
            tankcontroller.Move(position * speed * Time.deltaTime);
        }
    }
}
