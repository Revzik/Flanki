using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void reset()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void back() 
    {
        SceneManager.LoadScene("menu");
    }
}
