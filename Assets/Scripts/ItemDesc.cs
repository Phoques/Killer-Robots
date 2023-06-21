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

    HudText hudText;
    PdaStory pdaStoryClass;




    private void Start()
    {
        hudText = FindObjectOfType<HudText>();
        pdaStoryClass = FindObjectOfType<PdaStory>();
    }



    private void Update()
    {
        ItemInteraction();
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

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA1" && !isDownloading)
        {
            pdaStoryClass.isPDA1 = true;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, interactable) && hit.transform.tag == "PDA2" && !isDownloading)
        {
            pdaStoryClass.isPDA2 = true;
        }

    }

    private void ItemDescription()
    {
        Debug.Log("Description being shown");
        hudText.hudDisplay.enabled = true;
        hudText.hudDisplay.text = "A personal PDA";

        if (CompareTag("PDA1"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (CompareTag("PDA2"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (CompareTag("PDA3"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A personal PDA";
        }
        if (CompareTag("PowerCell"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A power generator";
        }
        if (CompareTag("Cryo"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A Cryo Stasis Pod";
        }
        if (CompareTag("Garbage Chute"))
        {
            hudText.hudDisplay.enabled = true;
            hudText.hudDisplay.text = "A garbage chute";
        }
        if (CompareTag("Keycard"))
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
                //If player downloads two in succession without checking the first, the latter PDA will not show.

                //Pickup Check

                if (!isDownloading)
                {
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



}
