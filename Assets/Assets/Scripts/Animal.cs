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
    public Animal(int id)
    {
        currentFaze = 0;
        this.id = id;
        switch (id)
        {
            case 0:
                this.purchaseValue = 0;
                this.collectPrize = 1;
                this.collectTime = 6;
                break;
            default:
                this.purchaseValue = 0;
                this.collectPrize = 1;
                this.collectTime = 6;
                break;
        }
    }
    private void Init(Animal animal)
    {
        this.id = animal.id;
        this.purchaseValue = animal.purchaseValue;
        this.collectPrize = animal.collectPrize;
        this.collectTime = animal.collectTime;
        RestartProduction();
    }
    private void Start()
    {
        isReady = transform.GetChild(0).gameObject;
        isReady.SetActive(false);
        StartCoroutine(PlayRandomAnimation());
        Init(new Animal(0));
    }


    private void Update()
    {
        
    }

    public IEnumerator SkipFaze(float time)
    {
        if (currentFaze > 0)
        {
            yield return new WaitForSeconds(0);
            isReady.SetActive(true);
        }
        yield return new WaitForSeconds(time);
        currentFaze++;
        StartCoroutine(SkipFaze(CollectTime));
    }

    private void Collect()
    {
        currentFaze = 0;
        isReady.SetActive(false);
        Profile.Balance += collectPrize;
        PlayCollectAnimation();
        SaveSystem.Save();
        Main.UpdateBalance();
    }
    private void RestartProduction()
    {
        StopCoroutine("SkipFaze");
        isReady.SetActive(false);
        StartCoroutine(SkipFaze(collectTime));
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentFaze < MaxFaze)
        {
            PopUpMessage.StartPopUpMessage(gameAssets.TextPrefabs[0], "Product is not ready!",Color.yellow);
            return;
        }
            Collect();
    }
    private void PlayCollectAnimation()
    {
        AnimationController.PlayAnimation(gameAssets.AnimationPrefabs[1], isReady.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite);
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
