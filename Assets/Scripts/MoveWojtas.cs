using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWojtas : MonoBehaviour
{
    public Transform can;
    public Transform wojtas;
    private Vector3 can_pos;
    private Vector3 wojtas_pos;
    private Quaternion can_rot;
    private float can_pos_y;
    private float can_pos_z;
    private float wojtas_pos_z;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("wojtas_forward", false);
        GetComponent<Animator>().SetBool("wojtas_back", false);
        wojtas_pos = wojtas.position;
        can_pos = can.position;
        can_rot = can.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        can_pos_y = can.position.y;
        can_pos_z = can.position.z;
        wojtas_pos_z = wojtas.position.z;

        if (can_pos_y <= 0.25f)
        {
            if (wojtas_pos_z > can_pos_z + 0.5f)
            {
                GetComponent<Animator>().SetBool("wojtas_forward", true);
                GetComponent<Rigidbody>().velocity = new Vector3(1, 0, -2.5f);
            }
            else if (wojtas_pos_z <= can_pos_z + 0.5f)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                can.position = can_pos;
                can.rotation = can_rot;
                can_pos_y = can.position.y;
            }
        }
        else
        {
            if (wojtas_pos_z < 5.95f)
            {
                GetComponent<Animator>().SetBool("wojtas_forward", false);
                GetComponent<Animator>().SetBool("wojtas_back", true);
                GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 2.5f);
            }
            else
            {
                GetComponent<Animator>().SetBool("wojtas_back", false);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                wojtas.position = wojtas_pos;
            }
        }
    }
}
