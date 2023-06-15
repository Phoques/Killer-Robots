using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{
    //This script needs to be attached directly to the object that has the light. 
    //In this case, the light is its own object ontop of the prefab, so if either have to find component in children, or attach it to the child object which is the light. 

    public bool changeLights;

    public Light lightTest; // This sets up a variable to be used for the light


    private void Start()
    {
        //This grabs the light component so that now I can change anything in the inspector.
        lightTest = GetComponent<Light>();
    }


    private void Update()
    {
        if (changeLights)
        {
            //lightTest.type = LightType.Spot; This doesnt appear to be needed. But good to know I suppose in case I want to change the light type?
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
