using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowToken : MonoBehaviour
{
    public Transform camera;
    public Rigidbody rb;
    public float distance = 1.0f;
    public float force = 100.0f;
    public float smoothing = 0.75f;
    private bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = camera.transform.forward * distance;
        transform.eulerAngles = camera.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {
            transform.position = camera.transform.position + camera.transform.forward * distance;
            transform.eulerAngles = camera.transform.eulerAngles;
            if (Input.GetMouseButtonDown(0))
            {
                thrown = true;
                rb.isKinematic = false;
                rb.AddForce(camera.transform.forward * force);
            }
        }
    }
}
