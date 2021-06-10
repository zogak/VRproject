using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eatScript : MonoBehaviour
{

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


}
