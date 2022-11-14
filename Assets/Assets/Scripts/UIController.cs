using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text balance;
    private void Start()
    {
        UpdateText("Balance: " + Profile.Balance);
    }
    public void UpdateText(string text)
    {
        balance.text = text;
    }
}
