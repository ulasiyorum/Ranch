using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    public static void StartPopUpMessage(GameObject prefab,string text)
    {
        GameObject obj =
        Instantiate(prefab,FindObjectOfType<Canvas>().transform,false);
        Destroy(obj, 2.5f);
    }
    
}
