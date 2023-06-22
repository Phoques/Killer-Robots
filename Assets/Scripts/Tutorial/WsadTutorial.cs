using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WsadTutorial : MonoBehaviour
{
    HudText hudTextClass;


    private void Start()
    {
        hudTextClass = FindObjectOfType<HudText>();
    }
    //Tag not working, probably using wrong library.
    private void OnTriggerStay(Collider other) // Might need to be ontriggerstay
    {
        Debug.Log("Tag not working");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("WSAD Engaged");
            hudTextClass.tutorialText.text = "";
            hudTextClass.tutorialText.text = "Use WSAD to move and the mouse to look around. \n \n Use Left Shift to Sprint \n \n Press 'E' to interact with objects \n \n Press 'L' to view PDA log";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("WSAD DISENGAGE");
            hudTextClass.tutorialText.text = "";

        }
    }

    // Adding this to force an update on Git.
}
