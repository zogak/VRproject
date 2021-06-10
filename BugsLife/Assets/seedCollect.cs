using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedCollect : MonoBehaviour
{

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("seed"))
        {
            GameManager.manager.seedcnt = true;
            Destroy(col.gameObject);
            audio.Play();
        }
    }
}
