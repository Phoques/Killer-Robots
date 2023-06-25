using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{
    //This script needs to be attached directly to the object that has the light. 
    //In this case, the light is its own object ontop of the prefab, so if either have to find component in children, or attach it to the child object which is the light. 

    //I have had to create 3 light scripts to individually control them, need to find a better way to do this.


    public Light light1; // This sets up a variable to be used for the light
    public Light light2;
    public Light light3;

    public Light[] sector1Lights;
    public Light[] sector2Lights;
    public Light[] sector3Lights;

    ItemDesc itemDesc;




    private void Start()
    {
        //This grabs the light component so that now I can change anything in the inspector. Unsure why all pieces dont work, this whole thing is fucking FUBAR...
        light1 = GetComponentInChildren<Light>();
        light2 = GetComponentInChildren<Light>();
        light3 = GetComponentInChildren<Light>();

        itemDesc = FindObjectOfType<ItemDesc>();
    }

    private void Update()
    {
        if (itemDesc.powercell1Off)
        {
            light1.color = Color.red;
            foreach (Light light in sector1Lights)
            {
                light.color = Color.red;
            }
        }
        if (itemDesc.powercell2Off)
        {
            light2.color = Color.red;
            foreach(Light light in sector2Lights)
            {
                light.color = Color.red;
            }
        }
        if (itemDesc.powercell3Off)
        {
            light3.color = Color.red;
            foreach( Light light in sector3Lights)
            {
                light.color = Color.red;
            }
        }

    }

}
