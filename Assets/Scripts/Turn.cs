using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Token token;
    public Transform player;
    public Can can;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        token.reset();

        can.reset();

        player.position = new Vector3(0.0f, 4.0f, -8.5f);
        player.eulerAngles = new Vector3(20.0f, 0.0f, 0.0f);
    }
}
