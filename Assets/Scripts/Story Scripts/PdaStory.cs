using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdaStory : MonoBehaviour
{

    HudText hudText;


    public bool isPDA1;
    bool isPDA2;
    bool isPDA3;

    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
    }

    public void PDACheck()
    {
        if (isPDA1)
        {
            PDA1();
        }
    }

    public void PDA1()
    {
        hudText.noteText.text = "Captains Log, 19081271 \n I found a donut the other day, boy was it tasty, omg killer robots someone HALP pls send the fkn Space marines or some shit \n Oh well im ded now fk";
        hudText.hudExitText.text = "Press (X) to close PDA notes";
    }
}
