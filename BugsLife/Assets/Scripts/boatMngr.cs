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
            Destroy(boat);

            //효과음

            //완성된 보트 생성
            Instantiate(realBoat, boatPos, Quaternion.identity);

            boat_make = true;

        }

        if(boat_make == true&&time<10.0f)
        {
            time += Time.deltaTime;
            realBoat.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
    }

}
