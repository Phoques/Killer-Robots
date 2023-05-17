using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdaStory : MonoBehaviour
{
    RaycastHit hit;

    HudText hudText;


    public bool isPDA1;
    bool isPDA2;
    bool isPDA3;

    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
    }



    public void PDA1()
    {
        if (isPDA1)
        {
            hudText.noteText.text = "Captains Log, 19081271 \n I found a donut the other day, boy was it tasty, omg killer robots someone HALP pls send the fkn Space marines or some shit \n Oh well im ded now fk";
            hudText.hudExitText.text = "Press (X) to close PDA notes";
        }
        else return;
    }


    //if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA1")
}
