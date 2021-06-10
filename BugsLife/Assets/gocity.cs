using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class gocity : MonoBehaviour
{
    bool go = false;
    int ment = 0;
    float timer;
    int waitingTime;
    public Text riverText;

    public void HandleSelectEnter(SelectEnterEventArgs args)
    {
        go = true;
    }
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;

    }
    void Update()
    {
        if (go == true)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                ment++;
                timer = 0;
            }
            if (ment == 1)
            {
                riverText.text = "All right, now I can cross the river!";
            }
            if (ment == 2)
            {
                riverText.text = "Here we go!";
            }
            if (ment == 3)
            {
                SceneManager.LoadScene("CityScene");
            }

        }
    }
}
