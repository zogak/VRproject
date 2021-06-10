using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public enum SquState
{
    inactive,
    appear,
    talking,
    move
}

public class UnderGroundNpc : MonoBehaviour
{
    [SerializeField]
    Transform[] appearPos;
    [SerializeField]
    Transform[] movePos;
    private int aPosNum = 0;
    private int mPosNum = 0;

    public float speed = 15f;

    public GameObject leftRay;
    public GameObject rightRay;
    public GameObject squirrel;

    private Animator squAnimator;

    private XRRayInteractor leftRayInteractor;
    private XRRayInteractor rightRayInteractor;

    public int howManyObjLeft = 4;
    private bool squirrelAppeared = false;

    public SquState squState = SquState.inactive;

    public AudioSource appeared;


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
            squState = SquState.appear;
            SquirrelComes();
            squAnimator.SetBool("Run", true);
        }

        if (squirrelAppeared && squState == SquState.appear)
        {
            squAnimator.SetBool("Run", false);
        }

        if(squState == SquState.move)
        {
            squAnimator.SetBool("Talk", false);
            squAnimator.SetBool("Walk", true);
            SquirrelMoves();
        }

        if(squState == SquState.talking)
        {
            squAnimator.SetBool("Talk", true);
            squAnimator.SetBool("Walk", false);
            squAnimator.SetTrigger("Origin");
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
            appeared.Play();
        }
       
    }

    void SquirrelMoves()
    {
        squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, movePos[mPosNum].position, speed * Time.deltaTime);
        squirrel.transform.LookAt(movePos[mPosNum]);

        if (squirrel.transform.position == movePos[mPosNum].position)
        {
            mPosNum++;
        }

        if (mPosNum == appearPos.Length)
        {
            squirrel.transform.localEulerAngles = new Vector3(0, (float)-18.156, 0);
            squState = SquState.talking;
        }
    }

}
