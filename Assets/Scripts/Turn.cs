using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Turn : MonoBehaviour
{
    public Token token;
    public Transform player;
    public Transform team1;
    public Transform team2;

    public delegate void PlayerDrink();
    public static event PlayerDrink OnPlayerDrink;
    public delegate void AiDrink();
    public static event AiDrink OnAiDrink;

    private bool finished = false;
    private int curT1 = 0;
    private int cntT1;
    private int curT2 = 0;
    private int cntT2;
    private bool playerTurn = true;
    private bool playerWin = true;
    private bool toppled = false;
    private float drinkingPeriod = 0.2f;
    private float nextDrinkingTime = 0.0f;


    void Start()
    {
        cntT1 = team1.childCount;
        cntT2 = team2.childCount;

        player.position = new Vector3(team1.GetChild(curT1).transform.position.x, 3.0f, -6.0f);
        player.eulerAngles = new Vector3(10.0f, 0.0f, 0.0f);

        Token.OnTimeOut += next;
        Can.OnTopple += topple;
    }

    void Update()
    {
        if (toppled && playerTurn) {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                playerDrink();
            }
        }
        if (Time.time > nextDrinkingTime) {
            nextDrinkingTime += drinkingPeriod;
            if (toppled && !playerTurn) {
                aiDrink();
            }
        }
    }

    public void next()
    {
        if (!finished) {
            if (playerTurn) {
                playerTurn = false;
                token.playerTurn = false;
                token.opponent = team2.GetChild(curT2).transform;
                do {
                    curT1++;
                    if (curT1 >= cntT1) {
                        curT1 = 0;
                    }
                } while (team1.GetChild(curT1).GetComponent<DrinkPlayer>().empty());
            }
            else {
                playerTurn = true;
                token.playerTurn = true;
                do {
                    curT2++;
                    if (curT2 >= cntT2) {
                        curT2 = 0;
                    }
                } while (team2.GetChild(curT2).GetComponent<DrinkAI>().empty());
            }

            player.position = new Vector3(team1.GetChild(curT1).transform.position.x, 3.0f, -6.0f);
            player.eulerAngles = new Vector3(10.0f, 0.0f, 0.0f);
            toppled = false;
        }
        /*else {
            if (playerWin) {
                GameObject.Find("WinText").GetComponent<Text>().text = "Gratulacje, wygrałeś!";
            }
            else {
                GameObject.Find("WinText").GetComponent<Text>().text = "Przeciwnik wygrał!";
            }
            showMenu();
        }*/
    }

    public void playerDrink()
    {
        if (OnPlayerDrink != null) {
            OnPlayerDrink();
        }

        int ctr = 0;
        for (int i = 0; i < cntT1; i++) {
            if (team1.GetChild(i).GetComponent<DrinkPlayer>().empty()) {
                ctr++;
            }
        }

        if (ctr == cntT1) {
            finished = true;
        }

        if (finished) {
            playerWin = true;
        }
    }

    public void aiDrink() {
        if (OnAiDrink != null) {
            OnAiDrink();
        }

        int ctr = 0;
        for (int i = 0; i < cntT2; i++) {
            if (team2.GetChild(i).GetComponent<DrinkAI>().empty()) {
                ctr++;
            }
        }

        if (ctr == cntT2) {
            finished = true;
        }

        if (finished) {
            playerWin = false;
        }
    }

    public void showMenu() {
        GameObject.Find("EndMenu").SetActive(true);
    }

    public void topple() {
        toppled = true;
    }

    public int getCurT2() {
        return curT2;
    }

    public bool getPlayerTurn() {
        return playerTurn;
    }
}