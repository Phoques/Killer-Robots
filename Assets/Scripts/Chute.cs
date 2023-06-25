using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{

    ItemDesc itemDescClass;
    PlayerMovement playerMovementClass;
    HudElements hudElementsClass;

    private void Start()
    {
        itemDescClass = FindObjectOfType<ItemDesc>();
        playerMovementClass = FindObjectOfType<PlayerMovement>();
        hudElementsClass = FindObjectOfType<HudElements>();
    }


    public IEnumerator GarbageTeleport()
    {
        hudElementsClass.fadeToBlack.enabled = true;
        yield return null;
        playerMovementClass.disableControls = true;
        playerMovementClass.ChuteTeleport();
        yield return new WaitForSeconds(1);
        hudElementsClass.fadeToBlack.enabled = false;
        playerMovementClass.disableControls = false;

    }
}
