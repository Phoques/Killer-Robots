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
        hudText.hudDisplay.enabled = false;
        Debug.Log("Coroutine Started");
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

        hudText.hudNotifications.enabled = true;
        hudText.hudNotificationsText.text = "PDA Note downloaded, press (N) to view PDA.";

        isDownloading = false;

        //Make bool to say its done, Add to a list to be viewed elsewhere.
    }

    private void ItemDescription()
    {
        Debug.Log("Description being shown");
        hudText.hudDisplay.enabled = true;
        hudText.hudDisplay.text = "This is a cube";
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
            
            isInteracting = true;
            if (isInteracting && !isDownloading)
            {
                ItemDescription();
            }

            Debug.Log("Hit the item");
            if (Input.GetKeyDown(KeyCode.E) && isInteracting) // Possibly do a raycast check here?
            {
                if (!isDownloading)
                {
                    //Need to figure out here how to run a check to see which item we interacted with.
                    StartCoroutine(DownloadPDA());
                }
                if (isDownloading)
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
