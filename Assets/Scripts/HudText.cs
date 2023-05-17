using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudText : MonoBehaviour
{
    public Image noteDisplay;
    public Text noteText;
    public Text hudDisplay;

    public Image hudNotifications;
    public Text hudNotificationsText;

    PdaStory pdaStoryClass;

    private void Start()
    {
        noteDisplay.enabled = false;
        hudNotifications.enabled = false;
        pdaStoryClass = FindObjectOfType<PdaStory>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            hudNotifications.enabled = false;
            hudNotificationsText.text = "";

            noteDisplay.enabled = true;
            pdaStoryClass.PDA1(); // Will need to workout how to trigger the different stories via the object interacted with.
        }
    }

}
