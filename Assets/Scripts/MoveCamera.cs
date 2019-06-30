using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Can can;
    public Turn turn;
    
    private Vector3 initPos;

    public float movingSpeed;
    public float height;

    private float moveHorizontal;
    private float moveVertical;
    private bool moving = false;

    void Start() 
    {
        Can.OnTopple += enableMove;
        Token.OnTimeOut += reset;
    }

    void Update()
    {
        if (moving) {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            transform.Translate(moveVertical * Time.deltaTime * movingSpeed * Vector3.forward);
            transform.Translate(moveHorizontal * Time.deltaTime * movingSpeed * Vector3.right);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                if (Vector3.Distance(transform.position, can.transform.position) < 3.5f) {
                    can.reset();
                }
            }

            if (!can.toppled && Vector3.Distance(transform.position, initPos) < 1.0f) {
                Token.resetAll();
            }
        }
    }

    void enableMove()
    {
        if (!turn.getPlayerTurn()) {
            moving = true;
            initPos = transform.position;
        }
    }

    void reset()
    {
        moving = false;
    }
}
