using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void HandleSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactable.CompareTag("GoThird"))
        {
            SceneManager.LoadScene("MorningForest");
            GameManager.manager.changeRiver();
            GameManager.manager.SceneStart = true;
        }
    }


}
