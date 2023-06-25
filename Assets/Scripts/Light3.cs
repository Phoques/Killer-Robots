using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light3 : MonoBehaviour
{

    public Light light3;

    public Light[] sector3Lights;

    ItemDesc itemDesc;




    private void Start()
    {

        light3 = GetComponentInChildren<Light>();

        itemDesc = FindObjectOfType<ItemDesc>();
    }

    private void Update()
    {

        if (itemDesc.powercell3Off)
        {
            light3.color = Color.red;
            foreach (Light light in sector3Lights)
            {
                light.color = Color.red;
            }
        }

    }
}
