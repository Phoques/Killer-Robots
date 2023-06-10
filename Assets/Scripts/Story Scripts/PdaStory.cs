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
    public Text PDAPanelText;
    PlayerMovement playerMovementClass;




    //May need an array to close em but then later on notebook might not work
    //public bool PDAFound = false;
    public bool isPDA1 = false;
    public bool isPDA2 = false;
    public bool isPDA3 = false;

    public bool PDA1Found = false;
    public bool PDA2Found = false;

    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
        PDAPanel.gameObject.SetActive(false);
        playerMovementClass = FindObjectOfType<PlayerMovement>();
        PDAButtonLogHide();

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            DisplayPDALog();
            CheckPDALog();
            playerMovementClass.UnlockCursor();
        }
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

    public void PDA1() // If you press 'e' after downloading, then viewing, THEN pressing e again will have PDA one show even after 'downloading other pda' but it only works one way
        //It does not have the same effect when you download pda2 first, then press e on pda2, then go pda 1, so need to find the bug. Maybe could remove 'interactable' layer or something?
    {
        hudText.noteText.text = "Captains Log, 19081271 \n I found a donut the other day, boy was it tasty, omg killer robots someone HALP pls send the fkn Space marines or some shit \n Oh well im ded now fk";
        hudText.hudExitText.text = "Press (X) to close PDA notes";

    }

    public void PDA2()
    {
        hudText.noteText.text = "Scientist log 1234 \n Robuts, they are gaining teh smarts \n Need to fix";
        hudText.hudExitText.text = "Press (X) to close PDA notes";

    }

    //Maybe look into finding a way to make it in the order found (non goal)
    public void PDA1Log()
    {
        PDAPanelText.text = "";
        PDAPanelText.text = "Captains Log, 19081271 \n I found a donut the other day, boy was it tasty, omg killer robots someone HALP pls send the fkn Space marines or some shit \n Oh well im ded now fk";
    }

    public void PDA2Log()
    {
        PDAPanelText.text = "";
        PDAPanelText.text = "Scientist log 1234 \n Robuts, they are gaining teh smarts \n Need to fix";
    }

    private void PDAButtonLogHide()
    {
        PDA1LogButton.gameObject.SetActive(false);
        PDA2LogButton.gameObject.SetActive(false);
    }

    public void CheckPDALog()
    {
        if (PDA1Found)
        {
            PDA1LogButton.gameObject.SetActive(true);
        }
        if (PDA2Found)
        {
            PDA2LogButton.gameObject.SetActive(true);
        }


    }

}
