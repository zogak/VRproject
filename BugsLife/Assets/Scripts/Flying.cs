using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class Flying : MonoBehaviour
{
    Rigidbody headRg;

    public void Start()
    {
        headRg = GameObject.FindGameObjectWithTag("head").GetComponent<Rigidbody>();
    }
    public void fly(SelectEnterEventArgs args)
    {
        if (args.interactable.CompareTag("dandalion"))
        {
            headRg.useGravity = false;
        }
    }
    public void fall(SelectExitEventArgs args)
    {
        if (args.interactable.CompareTag("dandalion"))
        {
            headRg.useGravity = true;
        }
    }
}
