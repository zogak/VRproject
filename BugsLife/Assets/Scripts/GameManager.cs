using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        menu,
        inGame,
        gameOver
    }

    private void Awake()
    {
        Debug.Log("manager awakes");
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        GameObject child = obj.transform.GetChild(0).gameObject;
        GameObject ccild = child.transform.GetChild(0).gameObject;
        ccild.GetComponent<FadeInOut>().OnFade(FadeState.FadeIn);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
