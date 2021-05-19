using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(col.gameObject);
            audioSource.Play();
        }
    }


}
