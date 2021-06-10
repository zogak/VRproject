using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    Rigidbody rb;
    float speed = 2f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
        //Vector3 getVel = new Vector3(0, 0, 1) * speed;
        //rb.velocity = getVel;
    }
}
