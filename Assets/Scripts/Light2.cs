using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2 : MonoBehaviour
{

    public Light light2;
    public Light[] sector2Lights;


    ItemDesc itemDesc;




    private void Start()
    {
        //This grabs the light component so that now I can change anything in the inspector. Unsure why all pieces dont work, this whole thing is fucking FUBAR...
        light2 = GetComponentInChildren<Light>();


        itemDesc = FindObjectOfType<ItemDesc>();
    }

    private void Update()
    {

        if (itemDesc.powercell2Off)
        {
            light2.color = Color.red;
            foreach (Light light in sector2Lights)
            {
                light.color = Color.red;
            }
        }


    }
}
