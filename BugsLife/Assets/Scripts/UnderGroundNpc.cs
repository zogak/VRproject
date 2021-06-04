using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UnderGroundNpc : MonoBehaviour
{
    public GameObject leftRay;
    public GameObject rightRay;

    private XRRayInteractor leftRayInteractor;
    private XRRayInteractor rightRayInteractor;

    // Start is called before the first frame update
    void Awake()
    {
        leftRayInteractor = leftRay.GetComponent<XRRayInteractor>();
        rightRayInteractor = rightRay.GetComponent<XRRayInteractor>();
    }

    public void ItemSelected()
    {
        Debug.Log("selected something");
        Debug.Log(gameObject.name);
        if (gameObject.name.Contains("Box")){
            Debug.Log("Box selected");
        }else if (gameObject.name.Contains("Leaves"))
        {
            Debug.Log("Leves selected");
        }else if (gameObject.name.Contains("prop"))
        {
            Debug.Log("Prop selecte");
        }else if (gameObject.name.Contains("Table"))
        {
            Debug.Log("Table selecte");
        }
        else
        {
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
