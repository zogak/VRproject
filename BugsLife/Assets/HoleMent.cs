using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HoleMent : MonoBehaviour
{

    bool go = false;
    int ment = 0;
    float timer;
    int waitingTime;
    public Text forestText;

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
            if (ment == 0)
            {
                forestText.text = "What is this hole?";
            }
            if (ment == 1)
            {
                forestText.text = "I think it's a passageway to somewhere.";
            }
            if (ment == 3)
            {
                forestText.text = "Let¡¯s go inside!";
            }

        }
    }
}
