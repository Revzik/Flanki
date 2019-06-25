using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showtxt : MonoBehaviour
{
    public Text t1;

    void Start()
    {
        t1.text = "";

        Can.OnTopple += showText;
        Token.OnTimeOut += reset;
    }

    void showText()
    {
        t1.text = "Trafiles!";
    }

    public void reset() {
        t1.text = "";
    }
}