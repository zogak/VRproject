using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Movetonext : MonoBehaviour
{
    public bool check = true;
    public void SelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactable.CompareTag("boat")) //��1(forest)->��2(underground)
        {
            check = false;
            StartCoroutine(WaitForIt());
            Debug.Log("hi");
            //SceneManager.LoadScene("CityScene");
        }

    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        check = true;
    }
}
