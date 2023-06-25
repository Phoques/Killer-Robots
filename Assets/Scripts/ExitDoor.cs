using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExitDoor : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask mask;
    ItemDesc itemDescClass;
    public GameObject door;
    public Transform openDoor;

    public bool powerCellWin = false;
    public bool doorCodeWin = false;
    public bool keyCardWin = false;

    private void Start()
    {
        itemDescClass = FindObjectOfType<ItemDesc>();
    }


    private void Update()
    {
        WinConditions();
    }

    private void OpenDoor()
    {
        Debug.Log("I've Escaped");

        //door.transform.position = openDoor.transform.position;

        door.transform.position = openDoor.transform.position;
    }


    private void WinConditions()
    {
        if (itemDescClass.powercell1Off && itemDescClass.powercell2Off && itemDescClass.powercell3Off)
        {
            powerCellWin = true;
            OpenDoor();
        }
        if (itemDescClass.hasKeycard)
        {
            keyCardWin = true;
        }
        if (itemDescClass.hasDoorCode)
        {
            doorCodeWin = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && doorCodeWin)
        {
            Debug.Log("Escape");
            OpenDoor();
        }
        if (other.gameObject.tag == "Player" && keyCardWin)
        {
            Debug.Log("Escape");
            OpenDoor();
        }
    }


}
