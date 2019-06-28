using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpejson : MonoBehaviour
{

    public Transform can;
    public Transform spejson;
    private Vector3 can_pos;
    private Vector3 spejson_pos;
    private Quaternion can_rot;
    private float can_pos_y;
    private float can_pos_z;
    private float spejson_pos_z;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("spejson_forward", false);
        GetComponent<Animator>().SetBool("spejson_back", false);
        spejson_pos = spejson.position;
        can_pos = can.position;
        can_rot = can.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        can_pos_y = can.position.y;
        can_pos_z = can.position.z;
        spejson_pos_z = spejson.position.z;

        if (can_pos_y <= 0.25f)
        {
            if (spejson_pos_z > can_pos_z + 0.5f)
            {
                GetComponent<Animator>().SetBool("spejson_forward", true);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2.5f);
            }
            else if (spejson_pos_z <= can_pos_z + 0.5f)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                can.position = can_pos;
                can.rotation = can_rot;
                can_pos_y = can.position.y;
            }
        }
        else
        {
            if (spejson_pos_z < 5.95f)
            {
                GetComponent<Animator>().SetBool("spejson_forward", false);
                GetComponent<Animator>().SetBool("spejson_back", true);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2.5f);
            }
            else
            {
                GetComponent<Animator>().SetBool("spejson_back", false);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                spejson.position = spejson_pos;
            }
        }
    }
}