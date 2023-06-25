using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDesc : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask interactable;
    public bool isInteracting = false;
    public bool isDownloading = false;
    public bool hasDownloaded = false;
    public bool hasAlreadyDownloadedPDA1 = false;
    public bool hasAlreadyDownloadedPDA2 = false;
    public bool hasAlreadyDownloadedPDA3 = false;
    public bool hasDoorCode = false;

    public bool powercell1Off = false;
    public bool powercell2Off = false;
    public bool powercell3Off = false;
    public bool powerIsOff = false;

    public bool garbageTravel = false;

    public bool hasKeycard = false;

    HudText hudText;
    PdaStory pdaStoryClass;
    ExitDoor exitDoorClass;
    PlayerMovement playerMovementClass;
    Chute chuteClass;
    Lights lightsClass;



    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
        pdaStoryClass = FindObjectOfType<PdaStory>();
        exitDoorClass = FindObjectOfType<ExitDoor>();
        playerMovementClass = FindObjectOfType<PlayerMovement>();
        chuteClass = FindObjectOfType<Chute>();
        lightsClass = FindObjectOfType<Lights>();
    }



    private void Update()
    {
        ItemInteraction();
        CheckPDAWin();
        CheckKeycardWin();
    }

    private void CheckPDAWin()
    {
        if (hasAlreadyDownloadedPDA1 && hasAlreadyDownloadedPDA2 && hasAlreadyDownloadedPDA3)
        {
            hasDoorCode = true;
        }
    }
    private void CheckKeycardWin()
    {
        if (hasKeycard)
        {
             exitDoorClass.keyCardWin = true;
        }
    }

    IEnumerator DownloadPDA()
    {
        
        Debug.Log("Coroutine Started");
        hudText.hudDisplay.enabled = false;
        isDownloading = true;
        hudText.downloadingText.text = "Downloading PDA";
        yield return new WaitForSecondsRealtime(1f);
        hudText.downloadingText.text = "";
        yield return new WaitForSecondsRealtime(0.4f);
        hudText.downloadingText.text = "Downloading PDA";
        yield return new WaitForSecondsRealtime(1f);
        hudText.downloadingText.text = "";
        yield return new WaitForSecondsRealtime(0.4f);
        hudText.downloadingText.text = "Downloading PDA";
        yield return new WaitForSecondsRealtime(1f);
        hudText.downloadingText.text = "";
        yield return new WaitForSecondsRealtime(0.4f);
        hudText.downloadingText.text = "Downloading PDA";
        yield return new WaitForSecondsRealtime(0.4f);
        hudText.downloadingText.text = "";

        hasDownloaded = true;

        hudText.hudNotifications.enabled = true;
        hudText.hudNotificationsText.text = "PDA Note downloaded, press (N) to view PDA.";

        isDownloading = false;

        //Make bool to say its done, Add to a list to be viewed elsewhere.
    }

    private void PDACheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA Info" && !isDownloading)
        {
            pdaStoryClass.isPDAInfo = true;
            PickupInteractable();
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA1" && !isDownloading)
        {
            pdaStoryClass.isPDA1 = true;
            PickupInteractable();
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA2" && !isDownloading)
        {
            pdaStoryClass.isPDA2 = true;
            PickupInteractable();
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA3" && !isDownloading)
        {
            pdaStoryClass.isPDA3 = true;
            PickupInteractable();
        }

    }

    private void PowerCellCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell1")
        {
            powercell1Off = true;
            Debug.Log("Powercell 1 Down.");
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell2")
        {
            powercell2Off = true;
            //Turn off lights
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell3")
        {
            powercell3Off = true;
            //Turn off lights
        }
    }

    private void KeyCardCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "Keycard")
        {
            hasKeycard = true;
            PickupInteractable();
        }
    }

    private void GarbageChuteCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "Garbage Chute")
        {
            Debug.Log("Teleporting to Garbage");
            //playerMovementClass.Teleport(); //Genuinely dont know why this isnt working, yet it works fine with the coroutine below??
            StartCoroutine(chuteClass.GarbageTeleport());
        }
    }

    private void ItemDescription()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA Info")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA1")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA2")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA3")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell1")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A power generator";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell2")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A power generator";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PowerCell3")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A power generator";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "Garbage Chute")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A garbage chute";
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "Keycard")
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A Security keycard";
        }

    }

    private void RemoveItemDescription()
    {
        Debug.Log("Description NOT being shown");
        hudText.hudDisplay.enabled = false;
    }

    private void ItemInteraction()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable))
        {
            Debug.Log("Item interaction is working");
            isInteracting = true;
            if (isInteracting && !isDownloading)
            {
                ItemDescription();
            }

            Debug.Log("Hit the item");
            if (Input.GetKeyDown(KeyCode.E) && isInteracting)
            {
                PDACheck();
                KeyCardCheck();
                PowerCellCheck();
                GarbageChuteCheck();


                if (!isDownloading)
                {
                    if (pdaStoryClass.isPDAInfo)
                    {
                        StartCoroutine(DownloadPDA());
                        
                    }
                    if (!hasAlreadyDownloadedPDA1 && pdaStoryClass.isPDA1 && !hasAlreadyDownloadedPDA1)
                    {
                        StartCoroutine(DownloadPDA());
                        hasAlreadyDownloadedPDA1 = true;
                        pdaStoryClass.PDA1Found = true;
                    }
                    if (!hasAlreadyDownloadedPDA2 && pdaStoryClass.isPDA2 && !hasAlreadyDownloadedPDA2)
                    {
                        StartCoroutine(DownloadPDA());
                        hasAlreadyDownloadedPDA2 = true;
                        pdaStoryClass.PDA2Found = true;
                    }
                    if (!hasAlreadyDownloadedPDA3 && pdaStoryClass.isPDA3 && !hasAlreadyDownloadedPDA3)
                    {
                        StartCoroutine(DownloadPDA());
                        hasAlreadyDownloadedPDA3 = true;
                        pdaStoryClass.PDA3Found = true;
                    }


                }
                else if (isDownloading)
                {
                    return;
                }

            }
        }
        else if (isDownloading)
        {
            RemoveItemDescription();
        }
        else
        {
            isInteracting = false;
            RemoveItemDescription();
        }
    }

    private void PickupInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable))
        {
            Destroy(hit.transform.gameObject);
        }
    }

}
