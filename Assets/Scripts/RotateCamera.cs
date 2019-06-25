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
        reset();

        Token.OnTimeOut += reset;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime;

        if (pitch > 90) pitch = 90;
        else if (pitch < -90) pitch = -90;

        if (yaw > 90) yaw = 90;
        else if (yaw < -90) yaw = -90;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void reset() {
        pitch = 0;
        yaw = 0;
    }
}
