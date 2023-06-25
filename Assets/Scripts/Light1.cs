using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1 : MonoBehaviour
{
    public Light light1;


    public Light[] sector1Lights;

    ItemDesc itemDesc;




    private void Start()
    {
        //This grabs the light component so that now I can change anything in the inspector. Unsure why all pieces dont work, this whole thing is fucking FUBAR...
        light1 = GetComponentInChildren<Light>();


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


    }
}
