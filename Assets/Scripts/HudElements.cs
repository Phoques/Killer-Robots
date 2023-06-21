using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HudElements : MonoBehaviour
{
    public Image hudAwareness;
    public Image hudEye;
    public Image hudroom;
    public Image fadeToBlack;

    public Image[] hudAwarenessArray;
    public Image[] hudEyeArray;
    public Image[] hudRoomArray;
    public Image[] hudColor;


    private void Start()
    {
        fadeToBlack.enabled = false;
    }


}
