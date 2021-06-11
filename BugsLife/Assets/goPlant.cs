using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class goPlant : MonoBehaviour
{
    bool go = false;
    int ment = 0;
    float timer;
    int waitingTime;
    public Text cityText;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "head")
        {
            go = true;
        }
    }

    void Start()
    {
        timer = 0.0f;
        waitingTime = 3;

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
            if (ment == 0)
            {
                cityText.text = "What's that sign up front?";
            }
            if (ment == 1)
            {
                cityText.text = "Save the earth..?";
            }
            if (ment == 2)
            {
                cityText.text = "I need to go over there!";
            }

        }
    }
}
