using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showtxt : MonoBehaviour
{

    public Transform can;
    public Transform token;
    public Text t1;
    private Vector3 pos_can;
    private Vector3 pos_token;

    void Start()
    {
        t1.text = "";
    }

    void Update()
    {
        pos_can.y = can.position.y;
        pos_token.z = token.position.z;

        if (pos_can.y > 0.25 && pos_token.z >= 1)
        {
            t1.text = "Pudlo...";
        }
        else if (pos_can.y > 0.25 && pos_token.z < 1)
        {
            t1.text = "";
        }
        else
        {
            t1.text = "Trafiles!";
        }
    }
}