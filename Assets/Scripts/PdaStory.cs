using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PdaStory : MonoBehaviour
{

    HudText hudText;
    RaycastHit hit;
    public LayerMask interactable;

    public GameObject PDAPanel;
    public Button PDA1LogButton;
    public Button PDA2LogButton;
    public Button PDA3LogButton;
    public Text PDAPanelText;
    PlayerMovement playerMovementClass;




    //May need an array to close em but then later on notebook might not work
    //public bool PDAFound = false;
    public bool isPDAInfo = false;
    public bool isPDA1 = false;
    public bool isPDA2 = false;
    public bool isPDA3 = false;

    public bool PDA1Found = false;
    public bool PDA2Found = false;
    public bool PDA3Found = false;

    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
        PDAPanel.gameObject.SetActive(false);
        playerMovementClass = FindObjectOfType<PlayerMovement>();
        PDAButtonLogHide();

    }


    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.L))
        {

            DisplayPDALog();
            CheckPDALog();
            playerMovementClass.UnlockCursor();
        }*/

        //Canvas broke, I dont know why. Dont have time to fix.
    }

    private void DisplayPDALog()
    {
        PDAPanel.gameObject.SetActive(true);
        playerMovementClass.canMove = false;

    }

    public void ClosePDALog()
    {
        playerMovementClass.LockCursor();
        PDAPanel.gameObject.SetActive(false);
        playerMovementClass.canMove = true;
    }

    public void PDAInfo()
    {
        hudText.noteText.text = "PDA Log #14056: \n If you're reading this, that means you survived. Cryostasis causes amensia for the first 2 weeks, so you wont remember writing any of these, so I have hidden 3 more around the station to help you remnember and survive long enough to send for help. \n" +
            "Avoid the security drones, they've all turned on us! \n There's a few options for how you can get out of here alive. First way is to find a security card to unlock the vault door, " +
            "there'll be one in the security cell. But we sent Peter to try and retrieve it and he never came back so be careful! \n Second way is to take out the three power generators to force the station into emergency power which will trigger the door's locking mechanism to open." +
            " \n Last way is to assemble a device that can override the security system and open the door for you. We've made one, but we had to spread the parts of it out so the bots won't use it themselves. The location of the first part is in the Garbage disposal..";
        hudText.hudExitText.text = "Press (X) to close PDA notes";
    }

    public void PDA1() 
    {
        hudText.noteText.text = "I know its gross, but rummage past the top layer of garbage and you'll find the first piece of the hacking device... \n \n (You rummage and find a piece of the device!) \n \n Our best guess is that one of our industry rivals wanted to sabotage our cryogenics research. Unfounded public alarm has been raised over negligible evidence of memory loss and potential fatalities. " +
            "\nThose bloody rats will use any legal leverage they can find to bring down our great work. The next part of the override device is near the Security Cell. \n \nThe garbage chutes are safe to climb through if you need get back here or need to escape the security drones. Stay out of sight if you can.";
        hudText.hudExitText.text = "Press (X) to close PDA notes";

    }

    public void PDA2()
    {
        hudText.noteText.text = "Dont stay here long! The bots patrol this area! The next piece is on the back of this PDA \n \n (You turn the PDA over and get the second piece of the device!) \n \n The last piece is located in the archives, go past bot maintenence";
        hudText.hudExitText.text = "Press (X) to close PDA notes";

    }

    public void PDA3()
    {
        hudText.noteText.text = "If you're reading this you made it, the last piece is hidden just near the column. \n \n (You search near the column and find the last piece, and put the device together) \n \n  Dont forget to send for help, we are all counting on you.. Once the parts are together, take it to the door and it should automatically override the lock....I hope we'll get to see our families again.";
        hudText.hudExitText.text = "Press (X) to close PDA notes";

    }

    //Maybe look into finding a way to make it in the order found (non goal)
    public void PDA1Log()
    {
        PDAPanelText.text = "";
        PDAPanelText.text = "PDA Log #14056: \n If you're reading this, that means someone survived. I've hidden a few of my personal logs around the station to hopefully help you survive long enough to send for help. \n" +
            "Avoid the security drones, the day after we managed to successfully enter personnel into cryo stasis they all just turned on us, but we cant hide forever. \n There's a few options for how you can get out of here alive. First way is to find a security card to unlock the vault door, " +
            "there'll be one in the security cell. But we sent Peter to try and retrieve it and he never came back so be careful! \n Second way is to take out the three power generators to force the station into emergency power which will trigger the door's locking mechanism to open." +
            " \n Last way is to assemble a device that can override the security system and open the door for you. We've made one, but we had to spread the parts of it out so the bots won't use it themselves. The location of the first part is [Location]";
    }

    public void PDA2Log()
    {
        PDAPanelText.text = "";
        PDAPanelText.text = "Our best guess is that one of our industry rivals wanted to sabotage our cryogenics research. Unfounded public alarm has been raised over negligible evidence of memory loss and potential fatalities. " +
            "\nThose bloody rats will use any legal leverage they can find to bring down our great work. The next part of the override device is at [location]. The garbage chutes are safe to climb through if you need an alternate path or need to escape the security drones. Stay out of sight if you can.";
    }

    public void PDA3Log()
    {
        PDAPanelText.text = "";
        PDAPanelText.text = "At the time of recording, it is unsafe for me and the team to leave this room. We're going to put ourselves in cryo and hopefully those crazy bots will wear themselves out before we wake up. \n The last part of the override mechanism is at [location]. Once the parts are together, take it to the door and override that lock....I hope we'll get to see our families again.";
    }


    private void PDAButtonLogHide()
    {
        PDA1LogButton.gameObject.SetActive(false);
        PDA2LogButton.gameObject.SetActive(false);
        PDA3LogButton.gameObject.SetActive(false);
    }

    public void CheckPDALog()
    {
        if (PDA1Found)
        {
            Debug.Log("PDA 1 found");
            PDA1LogButton.gameObject.SetActive(true);
        }
        if (PDA2Found)
        {
            Debug.Log("PDA 2 found");
            PDA2LogButton.gameObject.SetActive(true);
        }
        if (PDA3Found)
        {
            Debug.Log("PDA 3 found");
            PDA3LogButton.gameObject.SetActive(true);
        }


    }

}
