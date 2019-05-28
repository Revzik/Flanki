using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0;
    private float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
