using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    [SerializeField] Crop crop;
    [SerializeField] Text[] prices;
    public GameAssets assets;
    private void Start()
    {
        AllTextsUpdated();
    }

    public void UpdatePrice(int price,int index)
    {
        Profile.PriceList[index] = price;
        prices[index].text = price.ToString();
    }

    public void Buy(int buy)
    {
        int price = int.Parse(prices[buy].text);
        if (price > Profile.Balance)
        {
            PopUpMessage.StartPopUpMessage(assets.TextPrefabs[0],"Not Enough Balance");
            return;
        }
        Profile.Balance -= Profile.PriceList[buy];
        switch (buy)
        {
            case 0:
                Profile.ExtraCrop++;
                Crop.PerksInit(crop);
                SaveSystem.Save();
                UpdatePrice(Profile.PriceList[buy] + Profile.PriceList[buy] * 4 * Profile.ExtraCrop, buy);
            break;
            case 1:
                Profile.RegrowFaster++;
                Crop.PerksInit(crop);
                SaveSystem.Save();
                UpdatePrice((Profile.PriceList[buy] - 3) * 5 * (Profile.RegrowFaster+1), buy);
            break;
        }
    }
    private void AllTextsUpdated()
    {
        if (Profile.PriceList == null)
            return;
        int i = 0;
        foreach (Text text in prices)
        {
            text.text = Profile.PriceList[i].ToString();
            i++;
        }
    }
}