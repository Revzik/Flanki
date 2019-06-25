using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turn : MonoBehaviour
{
    public Token token;
    public Transform playerCamera;
    public Transform team1;
    public Transform team2;

    private bool finished = false;
    private int curT1 = 0;
    private int cntT1;
    private int curT2 = 0;
    private int cntT2;
    private bool playerTurn = true;


    void Start()
    {
        cntT1 = team1.childCount;
        cntT2 = team2.childCount;

        Token.OnTimeOut += next;
    }

    public void next()
    {
        if (playerTurn) {
            playerTurn = false;
            token.playerTurn = false;
            token.opponent = team2.GetChild(curT2).transform;
            curT1++;
            if (curT1 >= cntT1) {
                curT1 = 0;
            }
        }
        else {
            playerTurn = true;
            token.playerTurn = true;
            curT2++;
            if (curT2 >= cntT2) {
                curT2 = 0;
            }
        }

        playerCamera.position = new Vector3(team1.GetChild(curT1).transform.position.x, 2.0f, -6.0f);
        playerCamera.eulerAngles = new Vector3(10.0f, 0.0f, 0.0f);
    }
}
