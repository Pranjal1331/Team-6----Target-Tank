using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurrent : MonoBehaviour
{
    public Transform turrent;
    //public Transform cannon;
    public float s_turrent;
    //public float s_cannon;
    float a_turrent;
    //float a_cannon;

    // Update is called once per frame
    void Update()
    {
        Rotate_turrent();
        //Rotate_cannon();
    }

    void Rotate_turrent()
    {
        a_turrent += Input.GetAxis("Mouse X") * s_turrent * -Time.deltaTime;
        a_turrent = Mathf.Clamp(a_turrent, -60, 60);
        turrent.localRotation = Quaternion.AngleAxis(a_turrent, Vector3.back);
    }

    /*void Rotate_cannon()
    {
        a_cannon += Input.mouseScrollDelta.y * s_cannon * -Time.deltaTime;
        a_cannon = Mathf.Clamp(a_cannon, -40, 40);
        cannon.localRotation = Quaternion.AngleAxis(a_cannon, Vector3.right);
    }*/
}
