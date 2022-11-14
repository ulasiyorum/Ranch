using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text balance;
    public void UpdateText(string text)
    {
        balance.text = text;
    }
}
