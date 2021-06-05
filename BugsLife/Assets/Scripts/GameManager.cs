using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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

    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "MorningForest") //morningforest씬 활성화되었다면
        {
            if(nowScene == Scene.forest) //첫번째 장면
            {
                
            }
            if(nowScene == Scene.river) //세번째 장면(강가)
            {
                if (SceneStart == true)
                {
                    //goRiverPoint();  //강가 위치로 player 위치 전환시키는 함수. 하지만 player 오브젝트의 xr rig 컴포넌트로 인해 원래 위치로 다시 돌아옴.
                    SceneStart = false;
                }
 
                }
            }

        if (SceneManager.GetActiveScene().name == "Underground") //underground씬 활성화되었다면
            {
            if (SceneStart == true)
            {
                //underground씬 전환 시 설정해야하는 것 있으면 여기에 넣으면 됩니다.
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
