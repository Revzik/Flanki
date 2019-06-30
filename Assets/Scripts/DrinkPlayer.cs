using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkPlayer : MonoBehaviour
{
    public Slider slider;

    public float drinkingSpeed;
    public float amount;

    // Start is called before the first frame update
    void Start()
    {
        amount = 1000;
        drinkingSpeed += (Random.value * 6.0f - 3.0f);

        Turn.OnPlayerDrink += drink;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = amount;
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
