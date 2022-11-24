using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animal : MonoBehaviour,ICollectable,IPointerDownHandler
{
    public GameAssets gameAssets;
    private const int MaxFaze = 1;
    private int id;
    private int purchaseValue;
    private int collectPrize;
    private float collectTime;
    private int currentFaze;
    private GameObject isReady;

    public int ID { get => id; set => id = value; }
    public int PurchaseValue { get => purchaseValue; set => purchaseValue = value; }
    public float CollectTime { get => collectTime; set => collectTime = value; }
    public int CollectPrize { get => collectPrize; set => collectPrize = value; }
    public int CurrentFaze { get => currentFaze; set => currentFaze = value; }

    private void Start()
    {
        isReady = GetComponentInChildren<GameObject>();
        isReady.SetActive(false);
    }


    private void Update()
    {
        
    }

    public IEnumerator SkipFaze(float time)
    {
        if (currentFaze != 0)
            yield return new WaitForSeconds(0);

        yield return new WaitForSeconds(time);
        currentFaze++;
        isReady.SetActive(true);
    }

    private void Collect()
    {
        isReady.SetActive(false);
        Profile.Balance += collectPrize;
        PlayCollectAnimation();
        SaveSystem.Save();
        Main.UpdateBalance();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentFaze < MaxFaze - 1)
        {
            PopUpMessage.StartPopUpMessage(gameAssets.TextPrefabs[0], "Product is not ready!",Color.yellow);
            return;
        }
        else
        {
            Collect();
            StartCoroutine(SkipFaze(collectTime));
        }
    }
    private void PlayCollectAnimation()
    {
        AnimationController.PlayAnimation(gameAssets.AnimationPrefabs[id], isReady.GetComponentInChildren<SpriteRenderer>().sprite);
    }
}
