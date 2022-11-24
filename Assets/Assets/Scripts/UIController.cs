using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] string _text;
    private void Awake()
    {
        if(text != null)
        UpdateText(_text);
    }
    public void UpdateText(string text)
    {
        this.text.text = text;
    }
    public static void UpdateText(Text text, string str)
    {
        text.text = str;
    }
}
