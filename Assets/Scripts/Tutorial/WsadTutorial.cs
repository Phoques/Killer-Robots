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
    private void OnTriggerEnter(Collider other) // Might need to be ontriggerstay
    {
        Debug.Log("Tag not working");
        if (gameObject.tag == "Player")
        {
            Debug.Log("WSAD Engaged");
            hudTextClass.tutorialText.text = "";
            hudTextClass.tutorialText.text = "Use WSAD to move and the mouse to look around.";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log("WSAD DISENGAGE");
            hudTextClass.tutorialText.text = "";

        }
    }


}
