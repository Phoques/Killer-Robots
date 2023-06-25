using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    HudElements hudElements;

        private void Start()
    {
        hudElements = FindObjectOfType<HudElements>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hudElements.gameOver.enabled = true;
            hudElements.gameOverText.enabled = true;
        }
    }
}
