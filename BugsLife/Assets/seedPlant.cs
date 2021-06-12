using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class seedPlant : MonoBehaviour
{
    Rigidbody rb;
    bool go = false;
    int ment = 0;
    float timer;
    float speed = 3.0f;
    int waitingTime;
    public Text cityText;
    public GameObject sprout;
    ContactPoint contact;
    GameObject instantiate;

    public Image blackOut;
    public Image logo;
    public TextMeshProUGUI credit;
    public GameObject volumeBefore;
    public GameObject volumeAfter;

    public AudioSource backGround;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("seed"))
        {
            Destroy(col.gameObject);
            contact = col.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.down, contact.normal);
            Vector3 pos = contact.point - new Vector3(0, 2.3f, 0);
            instantiate = Instantiate(sprout, pos, rot);
            go = true;
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
                cityText.text = "Even if I plant this seed...";
            }
            if (ment == 1)
            {
                cityText.text = "Can plants grow in this polluted city..?";
            }
            if (ment == 2)
            {
                instantiate.transform.Translate(Vector3.up * Time.deltaTime);
            }
            if (ment == 3)
            {
                cityText.text = "Wow, the plants have grown...!";
            }
            if (ment == 4)
            {
                cityText.text = "Maybe if you plant more seeds and take good care of it,";
            }
            if (ment == 5)
            {
                cityText.text = "we can restore the environment!";
            }
            if (ment == 6)
            {
                cityText.text = "As it says on that sign...";
            }
            if (ment == 7)
            {
                cityText.text = "Let's save the earth!!!";
                Invoke("Ending", 3);
            }

        }
        
    }

    void Ending()
    {
        volumeBefore.SetActive(false);
        volumeAfter.SetActive(true);

        backGround.Stop();
        GetComponent<AudioSource>().Play();

        //fade 오브젝트 가져와서 알파값 최대로
        blackOut.gameObject.SetActive(true);
        Color canvasColor = blackOut.color;
        canvasColor.a = 255;
        blackOut.color = canvasColor;

        logo.gameObject.SetActive(true);
        credit.gameObject.SetActive(true);
    }

}
