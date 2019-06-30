using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkAI : MonoBehaviour
{
    public float drinkingSpeed;
    public float amount;

    // Start is called before the first frame update
    void Start()
    {
        amount = 1000;

        drinkingSpeed += (Random.value * 8.0f - 4.0f);

        Turn.OnAiDrink += drink;
    }

    public void drink() {
        amount -= drinkingSpeed;
        if (amount < 0) {
            amount = 0;
            GetComponent<Renderer>().enabled = false;
        }
    }

    public bool empty() {
        return amount == 0;
    }
}
