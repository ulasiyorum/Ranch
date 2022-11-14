using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crop : MonoBehaviour,IUpgradable,IPointerDownHandler
{
    public GameAssets gameAssets;
    public UIController controller;
    private const int MaxFaze = 3;
    private int id;
    private int purchaseValue;
    private int collectPrize;
    private float collectTime;
    private int currentFaze;

    private bool coroutineRunning = false;

    private void Start()
    {
        CollectPrize = 1;
        collectTime = 2;
        id = 0;
        CurrentFaze = 0;
        StartCoroutine(SkipFaze());
    }


    private void FixedUpdate()
    {
        
    }
    public int ID { get => id; set => id = value; }
    public int PurchaseValue { get => purchaseValue; private set => purchaseValue = value; }
    public int CollectPrize { get => collectPrize; private set => collectPrize = value; }
    public float CollectTime { get => collectTime; private set => collectTime = value; }
    public int CurrentFaze { get => currentFaze; private set => currentFaze = value; }


    public IEnumerator SkipFaze()
    {
        if (currentFaze >= MaxFaze - 1) { yield return new WaitForSeconds(0); }
        else
        {
            yield return new WaitForSeconds(collectTime);
            currentFaze++;
            GetComponent<SpriteRenderer>().sprite = gameAssets.CropSprites[id+CurrentFaze];
            StartCoroutine(SkipFaze());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentFaze < MaxFaze - 1)
        {
            PopUpMessage.StartPopUpMessage(gameAssets.TextPrefabs[0], "Crop Is Not Yet Ready To Harvest.");
            return;
        }
        else
        {
            Collect();
            StartCoroutine(SkipFaze());
        }
        
    }
    private void Collect()
    {
        currentFaze = 0;
        GetComponent<SpriteRenderer>().sprite = gameAssets.CropSprites[id + CurrentFaze];
        Profile.Balance += collectPrize + Profile.ExtraCrop;
        controller.UpdateText("Balance: " + Profile.Balance);
        PlayCollectAnimation();
    }
    private void PlayCollectAnimation()
    {
        AnimationController.PlayAnimation(gameAssets.AnimationPrefabs[id], gameAssets.CropSprites[id+2]);
    }
}
