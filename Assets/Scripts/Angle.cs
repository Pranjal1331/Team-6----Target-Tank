using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
    private Vector3 rotation;
    [SerializeField] private float speed;


    // Update is called once per frame
    void Update()
    {
        if (rotation.magnitude <= 40)
        {
            if (Input.GetKey(KeyCode.UpArrow)) rotation = Vector3.left;
            else if (Input.GetKey(KeyCode.DownArrow)) rotation = Vector3.right;
            else rotation = Vector3.zero;

            transform.Rotate(rotation * speed * Time.deltaTime);
        }
       
    }
}
