using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Light torch;

    public bool torchOn = true;

    private void Start()
    {
        torch = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (torchOn)
            {
                torch.enabled = false;
                torchOn = false;

            }
            else if(!torchOn)
            {
                torch.enabled = true;
                torchOn = true;
            }
        }
    }
}
