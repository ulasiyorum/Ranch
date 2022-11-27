using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    public static Main Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Main>();
            }
            return instance;
        }
    }

    [SerializeField] GameObject farm;
    public GameObject Farm { get => farm; }
    [SerializeField] Crop crop;
    private static UIController controller;
    private void Awake()
    {
        controller = GetComponent<UIController>();
        if (SaveSystem.FileExists())
        {
            ProfileData data = SaveSystem.Load();
            crop.Init(new Crop(data.Crop));
            Profile.Load(data);
            Crop.PerksInit(crop);
            if(data.Animal != -1)
            {
                Buyable.GetBuyable(data.Animal).Event.Invoke(GameAssets.Instance);
            }
        }
        else
        {
            crop.StartCoroutine(crop.SkipFaze(crop.CollectTime));
        }
    }
    void Start()
    {
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
