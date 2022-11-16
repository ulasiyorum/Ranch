using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    [SerializeField] Text[] prices;
    public GameAssets assets;

    private void Start()
    {
        AllTextsUpdated();
    }

    public static void UpdatePrice(Text priceText,int price)
    {
        priceText.text = price.ToString();
    }

    public void Buy(int buy)
    {
        int price = int.Parse(prices[buy].text);
        if (price > Profile.Balance)
        {
            PopUpMessage.StartPopUpMessage(assets.TextPrefabs[0],"Not Enough Balance");
            return;
        }
        switch (buy)
        {
            case 0:
                Profile.ExtraCrop++;
                UpdatePrice(prices[0],price + price * 4 * (Profile.ExtraCrop));
            break;
        }
    }
    private void AllTextsUpdated()
    {
        foreach(Text text in prices)
        {
            if (!int.TryParse(text.text, out int result))
                return;

            int price = int.Parse(text.text);
            switch (System.Array.IndexOf(prices,text))
            {
                case 0:
                    text.text = (price + price * 4 * (Profile.ExtraCrop)).ToString();
                    break;
            }
        }
    }
}
