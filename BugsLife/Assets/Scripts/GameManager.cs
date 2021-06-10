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
    public bool SceneStart = false; //장면이 시작됨을 알려주는 변수. 장면 시작 시, initialize해야하는 것들을 처리하기위해 사용.

    //boat관련 변수들 입니다
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


        //장면 전환 시 하나의 게임 매니저만 유지되도록 설정
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
        
        if (SceneManager.GetActiveScene().name == "MorningForest") //morningforest씬 활성화되었다면
        {
            if(nowScene == Scene.forest) //첫번째 장면
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

        if (SceneManager.GetActiveScene().name == "Underground") //underground씬 활성화되었다면
            {
            if (SceneStart == true)
            {
                //underground씬 전환 시 설정해야하는 것 있으면 여기에 넣으면 됩니다.
                /*UNDERGROUND씬 시작 시 FADEIN*/ //동작을 안해서 주석처리
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

    public void goRiverPoint() //강가 위치로 player위치 전환하기 위한 함수
    {
        GameObject player = GameObject.FindWithTag("Player");
        Debug.Log(player.name);
        player.transform.position = new Vector3(746.0f, 22.43f, 206.43f);

    }

    public void changeUnderGround() //씬 상태를 underground로 설정하는 함수
    {
        nowScene = Scene.underground;
    }
    public void changeRiver() //씬 상태를 river로 설정하는 함수
    {
        nowScene = Scene.river;
    }
    
}
