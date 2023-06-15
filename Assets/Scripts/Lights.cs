using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{

    public bool changeLights;

    public Light lightTest;

    public GameObject lightTestPrefab;

    private void Start()
    {

        lightTest = GetComponent<Light>();
    }


    private void Update()
    {
        if (changeLights)
        {
            //lightTest.type = LightType.Spot;
            lightTest.color = Color.red;
        }
        else
        {
            //lightTest.type = LightType.Spot;
            lightTest.color = Color.white;
        }

        if(Input.GetKey(KeyCode.L))
        {
            changeLights = true;
        }
        else
        {
            changeLights = false;
        }
    }

}
