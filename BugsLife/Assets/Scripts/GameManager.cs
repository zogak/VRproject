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

    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "MorningForest") //morningforest�� Ȱ��ȭ�Ǿ��ٸ�
        {
            if(nowScene == Scene.forest) //ù��° ���
            {
                
            }
            if(nowScene == Scene.river) //����° ���(����)
            {
                if (SceneStart == true)
                {
                    //goRiverPoint();  //���� ��ġ�� player ��ġ ��ȯ��Ű�� �Լ�. ������ player ������Ʈ�� xr rig ������Ʈ�� ���� ���� ��ġ�� �ٽ� ���ƿ�.
                    SceneStart = false;
                }
 
                }
            }

        if (SceneManager.GetActiveScene().name == "Underground") //underground�� Ȱ��ȭ�Ǿ��ٸ�
            {
            if (SceneStart == true)
            {
                //underground�� ��ȯ �� �����ؾ��ϴ� �� ������ ���⿡ ������ �˴ϴ�.
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
