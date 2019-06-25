using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token : MonoBehaviour
{
    public Transform player;
    public Transform opponent;
    public Transform can;
    public Rigidbody token;
    public Slider throwStrength;

    public delegate void ResetMembers();
    public static event ResetMembers OnTimeOut;

    public float distance = 1.0f;
    public float smoothing = 0.75f;
    public float accuracy = 10.0f;
    public float thrownTimeout = 5.0f;
    public bool playerTurn = true;

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
        token.isKinematic = true;
        throwStrength.value = 0;

        Can.OnTopple += hit;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn) {
            playerThrow();
        }
        else {
            aiThrow();
        }
        
        if (thrown) {
            thrownTimer += Time.deltaTime;
            if (thrownTimer > thrownTimeout)  {
                if (OnTimeOut != null) {
                    OnTimeOut();
                }
                reset();
            }
        }
    }

    void playerThrow() 
    {
        if (!thrown) {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + player.transform.forward * distance, smoothing);
            transform.eulerAngles = player.transform.eulerAngles + new Vector3(0, 0, 90);

            if (!charging && Input.GetMouseButtonDown(0)) {
                charging = true;
                chargeStart = Time.time;
            }

            if (charging)  {
                force = (Time.time - chargeStart) * 333;
                if (force > 1000)  {
                    force = 1000;
                }
                throwStrength.value = force;
            }

            if (charging && Input.GetMouseButtonUp(0))  {
                charging = false;
                thrown = true;

                token.isKinematic = false;
                token.AddForce(player.transform.forward * force + new Vector3(Random.value * accuracy - accuracy / 2, Random.value * accuracy - accuracy / 2, 0));
            }
        }
    }

    void aiThrow() {
        //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        if (!thrown) {
            transform.position = opponent.position + new Vector3(0.0f, 2.0f, 0.0f);
            transform.LookAt(can);
            transform.eulerAngles = new Vector3(5.0f, transform.eulerAngles.y, 90.0f);

            token.isKinematic = false;
            token.AddForce(transform.forward * 500);
            thrown = true;
        }
    }

    void reset()
    {
        thrown = false;
        charging = false;
        thrownTimer = 0.0f;
        token.isKinematic = true;
        token.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        throwStrength.value = 0;
    }

    void hit()
    {
        thrownTimer = 0.0f;
    }
}
