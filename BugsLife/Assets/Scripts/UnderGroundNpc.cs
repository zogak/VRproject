using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UnderGroundNpc : MonoBehaviour
{
    [SerializeField]
    Transform[] appearPos;
    private int aPosNum = 0;

    public float speed = 15f;

    public GameObject leftRay;
    public GameObject rightRay;
    public GameObject squirrel;

    private Animator squAnimator;

    private XRRayInteractor leftRayInteractor;
    private XRRayInteractor rightRayInteractor;

    public int howManyObjLeft = 4;
    private bool squirrelAppeared = false;


    // Start is called before the first frame update
    void Awake()
    {
        leftRayInteractor = leftRay.GetComponent<XRRayInteractor>();
        rightRayInteractor = rightRay.GetComponent<XRRayInteractor>();

        squirrel.transform.position = appearPos[aPosNum].transform.position;
        aPosNum++;
        squirrel.SetActive(false);

        squAnimator = squirrel.GetComponent<Animator>();
    }

    public void ItemSelected()
    {
        Debug.Log("Item selected");
        howManyObjLeft--;
    }
    // Update is called once per frame
    void Update()
    {
        if(howManyObjLeft == 0 && !squirrelAppeared)
        {
            SquirrelComes();
            squAnimator.SetBool("Run", true);
        }

        if (squirrelAppeared)
        {
            SquirrelAnimations();
        }
    }

    void SquirrelComes()
    {
        if (!squirrel.activeInHierarchy)
        {
            squirrel.SetActive(true);
        }

        Debug.Log("Squirrel Comes");

        squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, appearPos[aPosNum].position, speed * Time.deltaTime);

        if(squirrel.transform.position == appearPos[aPosNum].position)
        {
            aPosNum++;
        }
       
        if(aPosNum == appearPos.Length)
        {
            squirrelAppeared = true;
        }
       
    }

    void SquirrelAnimations()
    {
        squAnimator.SetBool("Run", false);
    }
}
