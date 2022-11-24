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
        //isReady = GetComponentInChildren<GameObject>();
        //isReady.SetActive(false);
        StartCoroutine(PlayRandomAnimation());
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
    private IEnumerator PlayRandomAnimation()
    {
        Animator anim = GetComponent<Animator>();
        int condition = Random.Range(0, 10);
        if(condition < 2)
        {
            anim.SetTrigger("0");
        }
        else if(condition < 6)
        {
            anim.SetTrigger("1");
        }
        else
        {
            anim.SetTrigger("2");
        }
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + ((condition-2) * 1.2f));
        anim.SetTrigger("3");
        StartCoroutine(PlayRandomAnimation());
    }
}
