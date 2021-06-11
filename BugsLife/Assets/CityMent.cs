using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CityMent : MonoBehaviour
{

    int ment = 0;
    float timer;
    int waitingTime;
    public Text cityText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            ment++;
            timer = 0;
        }
        if (ment == 1)
        {
            cityText.text = "Well, I think I've crossed the river.";
        }
        if (ment == 2)
        {
            cityText.text = "What the...?";
        }
        if (ment == 3)
        {
            cityText.text = "Why is there so much trash?";
        }
        if(ment == 4)
        {
            cityText.text = "Maybe.. it's a city polluted by people.";
        }
        if (ment == 5)
        {
            cityText.text = "Oh, there's a seed in front of me!";
        }
        if (ment == 6)
        {
            cityText.text = "I got it from a squirrel. I dropped it..!";
        }
        if (ment == 7)
        {
            cityText.text = "I'm gonna go get it!!";
        }
        if (ment == 8)
        {
            cityText.text = " ";
        }
    }
}
