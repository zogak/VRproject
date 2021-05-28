using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logScript : MonoBehaviour
{
    
    public void socketFilled()
    {
        GameManager.manager.filledCount++;
        Debug.Log("filledCount is" + GameManager.manager.filledCount);
    }

    public void socketNotFilled()
    {
        GameManager.manager.filledCount--;
        Debug.Log("filledCount is" + GameManager.manager.filledCount);
    }
}
