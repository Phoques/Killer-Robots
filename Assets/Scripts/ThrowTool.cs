using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTool : MonoBehaviour
{
    public GameObject tool;

    public Vector3 chuck;

    public Transform toolPos;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        ThrowItem();
    }

    public void ThrowItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Debug.Log("Threw the thing");
            tool.GetComponent<Rigidbody>().useGravity = false;
            tool.transform.position = Vector3.forward;
        }
    }


}
