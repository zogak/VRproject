using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eatScript : MonoBehaviour
{
    bool go = false;
    int ment = 0;
    float timer;
    int waitingTime;
    public Text forestText;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Fruit"))
        {
            GameManager.manager.eatcnt= true;
            Destroy(col.gameObject);
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Load")
        {
            GameManager.manager.SceneStart = true;
            GameManager.manager.changeUnderGround();
            SceneManager.LoadScene("UnderGround");
            
        }

        if (col.gameObject.tag == "wall")
        {
            go = true;
        }

        if (col.gameObject.tag == "Fadeout")
        {
            /*
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            GameObject child = obj.transform.GetChild(0).gameObject;
            GameObject ccild = child.transform.GetChild(0).gameObject;
            GameObject cccild = ccild.transform.GetChild(0).gameObject;
            GameObject ccccild = cccild.transform.GetChild(0).gameObject;
            ccccild.GetComponent<FadeInOut>().OnFade(FadeState.FadeOut);
            */
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
                Debug.Log("hi");
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
