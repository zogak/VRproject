using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMngr : MonoBehaviour
{
    GameObject boat;
    Vector3 boatPos;

    public GameObject realBoat;

    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.Find("Boat");
        boatPos = boat.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.manager.filledCount == 6) //��Ʈ �ϼ�
        {
            //���� ����� �������
            Destroy(boat);

            //ȿ����

            //�ϼ��� ��Ʈ ����
            Instantiate(realBoat, boatPos, Quaternion.identity);
        }
    }
}
