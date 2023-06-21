using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudText : MonoBehaviour
{
    public Image noteDisplay;
    public Text noteText;
    public Text hudDisplay;
    public Text downloadingText;
    public Text tutorialText;

    public Image hudNotifications;
    public Text hudNotificationsText;
    public Text hudExitText;

    PdaStory pdaStoryClass;
    ItemDesc itemDescClass;

    private void Start()
    {
        noteDisplay.enabled = false;
        hudNotifications.enabled = false;
        pdaStoryClass = FindObjectOfType<PdaStory>();
        itemDescClass = FindObjectOfType<ItemDesc>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && itemDescClass.hasDownloaded)
        {
            
            hudNotifications.enabled = false;
            hudNotificationsText.text = "";

            if (pdaStoryClass.isPDA1)
            {
                noteDisplay.enabled = true;
                pdaStoryClass.PDA1();
                itemDescClass.hasDownloaded = false;
                pdaStoryClass.isPDA1 = false;

            }
            else if (pdaStoryClass.isPDA2)
            {
                noteDisplay.enabled = true;
                pdaStoryClass.PDA2();
                itemDescClass.hasDownloaded = false;
                pdaStoryClass.isPDA2 = false;

            }
            else if (pdaStoryClass.isPDA3)
            {
                noteDisplay.enabled = true;
                pdaStoryClass.PDA3();
                itemDescClass.hasDownloaded = false;
                pdaStoryClass.isPDA3 = false;

            }



        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            noteDisplay.enabled = false;
            noteText.text = "";
            hudExitText.text = "";
        }
    }



}
