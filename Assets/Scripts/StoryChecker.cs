using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChecker : MonoBehaviour
{
    public GameObject pdaNumber;

    public void CheckItem()
    {
        if(pdaNumber.tag == "PDA1")
        {
            Debug.Log("This is PDA1");
        }
        // It is only finding PDA, need to figure out why.
        else if (pdaNumber.tag == "PDA2")
        {
            Debug.Log("This is PDA2");
        }
    }
}
