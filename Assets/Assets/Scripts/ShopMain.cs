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
                UpdatePrice(Profile.PriceList[buy] + Profile.PriceList[buy] * 4 * Profile.ExtraCrop, buy);
                PopUpMessage.StartPopUpMessage(assets.TextPrefabs[1], "Upgrade Applied!");
                SaveSystem.Save();
            break;
            case 1:
                Profile.RegrowFaster++;
                Crop.PerksInit(crop);
                UpdatePrice((Profile.PriceList[buy] - 3) * 5 * (Profile.RegrowFaster + 1), buy);
                PopUpMessage.StartPopUpMessage(assets.TextPrefabs[1], "Upgrade Applied!");
                SaveSystem.Save();
            break;
        }
    }
    private void AllTextsUpdated()
    {
        if (Profile.PriceList == null)
            return;
        if(Profile.PriceList.Length == 0)
        {
            Profile.PriceList = new int[10];
            foreach(int buy in Profile.PriceList)
            {
                switch (System.Array.IndexOf(Profile.PriceList, buy))
                {
                    case 0:
                        Profile.PriceList[0] = 10;
                        break;
                    case 1:
                        Profile.PriceList[1] = 25;
                        break;
                }
            }
        }
        int i = 0;
        foreach (Text text in prices)
        {
            text.text = Profile.PriceList[i].ToString();
            i++;
        }
    }

    public void BuyMain(int buy)
    {
        Buyable item = Buyable.GetBuyable(buy);
        if (item == null)
            return;
        if(item.Price > Profile.Balance)
        {
            PopUpMessage.StartPopUpMessage(assets.TextPrefabs[0], "Not Enough Balance");
            return;
        }

        item.Event.Invoke(assets);
    }
}
