using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}
public class TextsUpdator : MonoBehaviour
{
    public TextMeshProUGUI playerThought;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private int dialogueNum = 0;

    private bool sInteractHappened = false;

    [SerializeField]
    private Dialogue[] squirrelDialogue;

    private void Awake()
    {
        
    }
    public void BoxInteract()
    {
        playerThought.gameObject.SetActive(true);
        playerThought.SetText("What's the box for? There seems to be acorns.");
        Invoke("invokeTextDisable", 5);
    }

    public void LeavesInteract()
    {
        playerThought.gameObject.SetActive(true);
        playerThought.SetText("The leaves are piled up. Maybe someone covered it up and slept?");
        Invoke("invokeTextDisable", 5);
    }

    public void TableInteract()
    {
        playerThought.gameObject.SetActive(true);
        playerThought.SetText("It's a wooden table. I'm too short to look up here.");
        Invoke("invokeTextDisable", 5);
    }

    public void PropInteract()
    {
        playerThought.gameObject.SetActive(true);
        playerThought.SetText("What is it for? Did someone living here have to draw water?");
        Invoke("invokeTextDisable", 5);
    }

    public void SquirrelInteract()
    {
        if (sInteractHappened)
        {
            return;
        }
        dialoguePanel.SetActive(true);
        SquirrelDialogue();
        sInteractHappened = true;
    }

    public void SquirrelDialogue()
    {
        Debug.Log("text");
        dialogueText.SetText(squirrelDialogue[dialogueNum].dialogue);
        dialogueNum++;
    }

    public void invokeTextDisable()
    {
        playerThought.gameObject.SetActive(false);
    }
}
