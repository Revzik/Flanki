using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowToken : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Slider throwStrength;
    public float distance = 1.0f;
    public float smoothing = 0.75f;
    public float accuracy = 5;
    private bool thrown = false;
    private bool charging = false;
    private float chargeStart = 0.0f;
    private float force;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.forward * distance;
        transform.eulerAngles = player.transform.eulerAngles + new Vector3(0, 0, 90);
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {
            transform.position = player.transform.position + player.transform.forward * distance;
            transform.eulerAngles = player.transform.eulerAngles + new Vector3(0, 0, 90);

            if (!charging && Input.GetMouseButtonDown(0))
            {
                charging = true;
                chargeStart = chargeStart = Time.time;
            }

            if (charging)
            {
                force = (Time.time - chargeStart) * 333;
                if (force > 1000)
                {
                    force = 1000;
                }
                throwStrength.value = force;
            }

            if (charging && Input.GetMouseButtonUp(0))
            {
                charging = false;
                thrown = true;

                rb.isKinematic = false;
                rb.AddForce(player.transform.forward * force + new Vector3(Random.value * accuracy - accuracy / 2, Random.value * accuracy - accuracy / 2, 0));
            }
        }
    }
}
