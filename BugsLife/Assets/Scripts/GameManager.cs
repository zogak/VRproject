using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int seednum = 0;
    public bool seedcnt = false;
    public bool eatcnt = false;
    private bool audiocnt = true;
    public Text forestText;

    int ment = 0;
    float timer;
    int waitingTime;


    AudioSource audioSource;

    public enum GameState
    {
        menu,
        inGame,
        gameOver
    };

    public enum Scene
    {
        forest,
        underground,
        river
    };

    
    public static GameManager manager;
    public Scene nowScene = Scene.forest;
    public bool SceneStart = false; //����� ���۵��� �˷��ִ� ����. ��� ���� ��, initialize�ؾ��ϴ� �͵��� ó���ϱ����� ���.

    //boat���� ������ �Դϴ�
    public int filledCount;
    //-------boat---------

    private void Awake()
    {
        manager = this;
        Debug.Log("manager awakes");
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        GameObject child = obj.transform.GetChild(0).gameObject;
        GameObject ccild = child.transform.GetChild(0).gameObject;
        GameObject cccild = ccild.transform.GetChild(0).gameObject;
        GameObject ccccild = cccild.transform.GetChild(0).gameObject;
        ccccild.GetComponent<FadeInOut>().OnFade(FadeState.FadeIn);


        //��� ��ȯ �� �ϳ��� ���� �Ŵ����� �����ǵ��� ����
        var find = FindObjectsOfType<GameManager>();

        if (find.Length == 1)
        {
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(manager);
        }


        
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 3;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        
        if (SceneManager.GetActiveScene().name == "MorningForest") //morningforest�� Ȱ��ȭ�Ǿ��ٸ�
        {
            if(nowScene == Scene.forest) //ù��° ���
            {
                if (timer > waitingTime)
                {
                    ment++;
                    timer = 0;
                }
                if (ment == 1)
                {
                    forestText.text = "Hmm.. Where the hell am I?";
                }
                else if (ment == 2)
                {
                    forestText.text = "Did I become a little bug?";
                }
                else if (ment == 3)
                {
                    if (audiocnt == true)
                    {
                        forestText.text = "Anywhy...";
                        audioSource.Play();
                        audiocnt = false;
                    }
                }
                else if (ment == 4)
                {
                    forestText.text = "Is this coming from my stomach?";

                }
                else if (ment == 5)
                {
                    forestText.text = "Oh there's some fruits!";
                }
                else if (ment == 6)
                {
                    forestText.text = "I wanna eat them now!!";
                }
                else if (ment == 7)
                {
                    forestText.text = " ";
                }

                if (eatcnt == true)
                {
                    int ran1 = Random.Range(0, 2);
                    if (ran1 == 0)
                    {
                        forestText.text = "Yummy!";
                    }
                    else
                    {
                        forestText.text = "I'm getting full!";
                    }
                    eatcnt = false;
                }
                if (seedcnt == true)
                {
                    seednum++;
                    if (seednum == 1)
                    {
                        forestText.text = "What is this seed..? ";
                    }
                    else
                    {
                        int ran = Random.Range(0, 2);
                        if (ran == 0)
                        {
                            forestText.text = "Oh! I got total " + seednum + " seeds!";
                        }
                        else
                        {
                            forestText.text = "Hmm..What can I do with these seeds..?";
                        }

                    }

                    seedcnt = false;

                }
            }
            
        }

        if (SceneManager.GetActiveScene().name == "Underground") //underground�� Ȱ��ȭ�Ǿ��ٸ�
            {
            if (SceneStart == true)
            {
                //underground�� ��ȯ �� �����ؾ��ϴ� �� ������ ���⿡ ������ �˴ϴ�.
                /*UNDERGROUND�� ���� �� FADEIN*/ //������ ���ؼ� �ּ�ó��
                /*
                GameObject obj = GameObject.FindGameObjectWithTag("Player");
                GameObject child = obj.transform.GetChild(0).gameObject;
                GameObject ccild = child.transform.GetChild(0).gameObject;
                GameObject cccild = ccild.transform.GetChild(0).gameObject;
                GameObject ccccild = cccild.transform.GetChild(0).gameObject;
                ccccild.GetComponent<FadeInOut>().OnFade(FadeState.FadeIn);
                */
                SceneStart = false;
            }
            
        }
    }

    public void goRiverPoint() //���� ��ġ�� player��ġ ��ȯ�ϱ� ���� �Լ�
    {
        GameObject player = GameObject.FindWithTag("Player");
        Debug.Log(player.name);
        player.transform.position = new Vector3(746.0f, 22.43f, 206.43f);

    }

    public void changeUnderGround() //�� ���¸� underground�� �����ϴ� �Լ�
    {
        nowScene = Scene.underground;
    }
    public void changeRiver() //�� ���¸� river�� �����ϴ� �Լ�
    {
        nowScene = Scene.river;
    }
    
}
