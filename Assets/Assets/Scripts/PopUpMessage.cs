using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    public static void StartPopUpMessage(GameObject prefab,string text)
    {
        prefab.GetComponent<Text>().text = text;
        GameObject obj =
        Instantiate(prefab,Main.Instance.Canvas.transform,false);
        Destroy(obj, 2.5f);
    }
    public static void StartPopUpMessage(GameObject prefab, string text,Color color)
    {
        Color startColor = prefab.GetComponent<Text>().color;
        prefab.GetComponent<Text>().text = text;
        prefab.GetComponent<Text>().color = color;
        GameObject obj =
        Instantiate(prefab, Main.Instance.Canvas.transform , false);
        Destroy(obj, 2.5f);
        prefab.GetComponent<Text>().color = startColor;
    }
}
