using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class riverStart : MonoBehaviour
{

    int ment = 0;
    float timer;
    int waitingTime;
    public Text riverText;

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
            riverText.text = "Oh! Out of the underground tunnel, there's a river! ";
        }
        if (ment == 2)
        {
            riverText.text = "How do we get past that river?";
        }
        if (ment == 3)
        {
            riverText.text = "Oops! There are logs out there?!";
        }
        if (ment == 4)
        {
            riverText.text = "I think I can make a boat out of those logs!";
        }
        if (ment == 5)
        {
            riverText.text = "Let's Move!";
        }
        if (ment == 6)
        {
            riverText.text = " ";
        }
    }
}
