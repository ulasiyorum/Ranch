using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crop : MonoBehaviour,ICollectable,IPointerDownHandler
{
    private const int MaxFaze = 3;
    private int id;
    private int purchaseValue;
    private int collectPrize;
    private float collectTime;
    private int currentFaze;

    private void Awake()
    {
        Profile.Balance = 1000;
        CollectPrize = 1;
        collectTime = 2;
        id = 0;
        CurrentFaze = 0;
        
    }
    private void Start()
    {

    }


    private void FixedUpdate()
    {
        
    }
    public int ID { get => id; set => id = value; }
    public int PurchaseValue { get => purchaseValue; private set => purchaseValue = value; }
    public int CollectPrize { get => collectPrize; private set => collectPrize = value; }
    public float CollectTime { get => collectTime; private set => collectTime = value; }
    public int CurrentFaze { get => currentFaze; private set => currentFaze = value; }


    public IEnumerator SkipFaze(float collectTime)
    {
        if (currentFaze >= MaxFaze - 1) { yield return new WaitForSeconds(0); }
        else
        {
            yield return new WaitForSeconds(collectTime);
            currentFaze++;
            GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.CropSprites[id+CurrentFaze];
            StartCoroutine(SkipFaze(collectTime));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentFaze < MaxFaze - 1)
        {
            PopUpMessage.StartPopUpMessage(GameAssets.Instance.TextPrefabs[0], "Crop Is Not Yet Ready To Harvest.");
            return;
        }
        Collect();
        StartCoroutine(SkipFaze(collectTime));
        
    }
    private void Collect()
    {
        currentFaze = 0;
        GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.CropSprites[id + CurrentFaze];
        Profile.Balance += collectPrize;
        Main.UpdateBalance();
        PlayCollectAnimation();
        SaveSystem.Save();
    }
    private void PlayCollectAnimation()
    {
        AnimationController.PlayAnimation(GameAssets.Instance.AnimationPrefabs[0], GameAssets.Instance.CropSprites[id+2]);
    }
    public void Init(Crop crop)
    {
        this.id = crop.id;
        this.purchaseValue = crop.purchaseValue;
        this.collectPrize = crop.collectPrize;
        this.collectTime = crop.collectTime;
        this.currentFaze = crop.currentFaze;
        RestartGrowing();
        
    }
    private void RestartGrowing()
    {
        StopAllCoroutines();
        GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.CropSprites[id + CurrentFaze];
        StartCoroutine(SkipFaze(collectTime));
    }
    public Crop(int id)
    {
        currentFaze = 0;
        this.id = id;
        switch (id)
        {
            case 0:
                this.purchaseValue = 0;
                this.collectPrize = 1;
                this.collectTime = 2;
            break;
            default:
                this.purchaseValue = 0;
                this.collectPrize = 1;
                this.collectTime = 2;
            break;
        }
    }
    public static void PerksInit(Crop c)
    {
        c.Init(new Crop(c.id));
        c.collectPrize += Profile.ExtraCrop;
        for(int i=0; i<Profile.RegrowFaster; i++)
        {
            float decreaseby = c.collectTime / 20;
            c.collectTime -= decreaseby;
        }
        Main.UpdateBalance();
    }
}
