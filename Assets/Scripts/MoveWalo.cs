using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalo : MonoBehaviour
{
    public Transform can;
    public Transform walo;
    private Vector3 can_pos;
    private Vector3 walo_pos;
    private Quaternion can_rot;
    private float can_pos_y;
    private float can_pos_z;
    private float walo_pos_z;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("walo_forward", false);
        GetComponent<Animator>().SetBool("walo_back", false);
        walo_pos = walo.position;
        can_pos = can.position;
        can_rot = can.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        can_pos_y = can.position.y;
        can_pos_z = can.position.z;
        walo_pos_z = walo.position.z;

        if (can_pos_y <= 0.25f)
        {
            if (walo_pos_z > can_pos_z + 0.5f)
            {
                GetComponent<Animator>().SetBool("walo_forward", true);
                GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -2.5f);
            }
            else if (walo_pos_z <= can_pos_z + 0.5f)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                can.position = can_pos;
                can.rotation = can_rot;
                can_pos_y = can.position.y;
            }
        }
        else
        {
            if (walo_pos_z < 5.95f)
            {
                GetComponent<Animator>().SetBool("walo_forward", false);
                GetComponent<Animator>().SetBool("walo_back", true);
                GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 2.5f);
            }
            else
            {
                GetComponent<Animator>().SetBool("walo_back", false);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                walo.position = walo_pos;
            }
        }
    }
}
