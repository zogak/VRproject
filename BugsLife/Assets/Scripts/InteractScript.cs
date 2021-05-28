using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{

    public void HandleSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactable.CompareTag("Load")) //¾À1(forest)->¾À2(underground)
        {
            SceneManager.LoadScene("UnderGround");
            GameManager.manager.changeUnderGround();
            GameManager.manager.SceneStart = true;
        }

        if (args.interactable.CompareTag("GoThird")) //¾À2(underground)->¾À3(river)
        {
            SceneManager.LoadScene("MorningForest");
            GameManager.manager.changeRiver();
            GameManager.manager.SceneStart = true;
        }


        if (args.interactable.CompareTag("Light")) //¾À2 Àüµî ºÒºû Á¶Àý
        {
            Debug.Log("hit");
            GameObject Light = args.interactable.transform.Find("Light").gameObject;
            GameObject Spot = args.interactable.transform.Find("Spotlight").gameObject;

            if (Light.GetComponent<Light>().enabled && Spot.GetComponent<Light>().enabled)
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
