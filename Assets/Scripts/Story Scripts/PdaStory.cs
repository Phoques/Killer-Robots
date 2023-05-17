using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdaStory : MonoBehaviour
{

    HudText hudText;

    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
    }

    public void PDA1()
    {
        hudText.noteText.text = "Captains Log, 19081271 \n I found a donut the other day, boy was it tasty, omg killer robots someone HALP pls send the fkn Space marines or some shit \n Oh well im ded now fk";
    }
}
