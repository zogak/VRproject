using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMngr : MonoBehaviour
{
    GameObject boat;
    Vector3 boatPos;

    public GameObject realBoat;
    bool boat_make = false;
    float speed = 3.0f;
    float time = 0;

    public GameObject particle;

   
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.Find("Boat");
        boatPos = boat.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.manager.filledCount == 6) //보트 완성
        {

            //원래 만든거 사라지고
            for(int i = 0; i<9; i++)
            {
                Destroy(boat.gameObject.transform.GetChild(i).gameObject);
            }

            particle.SetActive(false);

            //효과음

            //완성된 보트 생성
            Instantiate(realBoat, boatPos, Quaternion.Euler(new Vector3(-90, 0, 0)));

            boat_make = true;

        }

        if(boat_make == true&&time<10.0f)
        {
            time += Time.deltaTime;
            //realBoat.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
    }


}
