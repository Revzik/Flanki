using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public Rigidbody rb;
    public bool toppled = false;

    public delegate void ToppledAction();
    public static event ToppledAction OnTopple;


    void Start() 
    {
        Token.OnTimeOut += reset;
    }

    void Update() 
    {
        checkTopple();
    }

    void checkTopple() 
    {
        float x = transform.eulerAngles.x;
        float z = transform.eulerAngles.z;
        if (!toppled) {
            if ((x > 45 && x < 135) || (x < 315 && x > 225) || (z > 45 && z < 135) || (z < 315 && z > 225)) {
                if (!toppled && OnTopple != null) {
                    OnTopple();
                    toppled = true;
                }
            }
        }
    }

    public void reset()
    {
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        transform.position = new Vector3(0.0f, 0.3f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        toppled = false;
    }
}