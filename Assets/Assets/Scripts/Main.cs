using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] Crop crop;
    private static UIController controller;
    private void Awake()
    {
        if (SaveSystem.FileExists())
        {
            ProfileData data = SaveSystem.Load();
            crop.Init(new Crop(data.Crop));
            Profile.Load(data);
            Crop.PerksInit(crop);
        }
        else
        {
            crop.StartCoroutine(crop.SkipFaze(crop.CollectTime));
        }
    }
    void Start()
    {
        controller = FindObjectOfType<UIController>();
        UpdateBalance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateBalance()
    {
        controller.UpdateText("Balance: " + Profile.Balance);
    }
}
