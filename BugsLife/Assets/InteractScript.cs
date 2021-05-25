using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{

    public void HandleSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactable.CompareTag("Load"))
        {
            SceneManager.LoadScene("UnderGround");
        }

        if (args.interactable.CompareTag("Light"))
        {
            Debug.Log("hit");
            GameObject Light = args.interactable.transform.Find("Light").gameObject;
            GameObject Spot = args.interactable.transform.Find("Spotlight").gameObject;

            if(Light.GetComponent<Light>().enabled && Spot.GetComponent<Light>().enabled)
            {
                Light.GetComponent<Light>().enabled = false;
                Spot.GetComponent<Light>().enabled = false;
            }
            else
            {
                Light.GetComponent<Light>().enabled = true;
                Spot.GetComponent<Light>().enabled = true;
            }
        }
    }

}
