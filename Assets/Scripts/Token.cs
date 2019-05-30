using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour
{
    public Transform player;
    public Turn turn;
    public Rigidbody rb;
    public Slider throwStrength;
    public float distance = 1.0f;
    public float smoothing = 0.75f;
    public float accuracy = 10.0f;
    public float thrownTimeout = 5.0f;
    private bool thrown = false;
    private bool charging = false;
    private float chargeStart = 0.0f;
    private float force = 0.0f;
    private float thrownTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.forward * distance;
        transform.eulerAngles = player.transform.eulerAngles + new Vector3(0, 0, 90);
        rb.isKinematic = true;
        throwStrength.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (thrown)
        {
            thrownTimer += Time.deltaTime;
            if (thrownTimer > thrownTimeout)
            {
                turn.next();
            }
        }

        if (!thrown)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + player.transform.forward * distance, smoothing);
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

    public void reset()
    {
        thrown = false;
        charging = false;
        thrownTimer = 0.0f;
        rb.isKinematic = true;
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        throwStrength.value = 0;
    }

    public void hit()
    {
        thrownTimer = 0.0f;
    }
}
