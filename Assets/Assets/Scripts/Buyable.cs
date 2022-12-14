using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable
{
    public int Price { get; set; }
    public int ID { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public double Multiplier { get; set; }
    public Action<GameAssets> Event { get; set; }

    public Buyable(int price, int iD, int level, double multiplier)
    {
        Price = price;
        ID = iD;
        Level = level;
        Multiplier = multiplier;
        Event = ID switch
        {
            0 => Event0,
            1 => Event1,
            2 => Event2,
            _ => null
        };
    }
    public Buyable()
    {
 
    }
    public static Buyable GetBuyable(int buy) => buy switch
    {
        0 => new Buyable(750,0,1,1),
        1 => new Buyable(1500,1,1,1),
        2 => new Buyable(400,2,1,1),
        _ => null
    };

    public static void Event0(GameAssets assets)
    {
        ClearAnimals();
        Profile.Animal = 0;
        GameObject.Instantiate(assets.AnimalPrefabs[0],Main.Instance.Farm.transform,false);
    }
    public static void Event1(GameAssets assets)
    {
        ClearAnimals();
        Profile.Animal = 1;
        GameObject.Instantiate(assets.AnimalPrefabs[1], Main.Instance.Farm.transform, false);
    }
    public static void Event2(GameAssets assets)
    {
        Profile.Crop = 1;
        Crop bought = new Crop(Profile.Crop);
        Main.Instance.Crop.Init(bought);
        Crop.PerksInit(Main.Instance.Crop);
    }
    // Shop is planned to have more things than just animals so that's why it's implemented like this : It's not finished
    public static void ClearAnimals()
    {
        if (GameObject.FindObjectOfType<Animal>() == null)
            return;
        Profile.Animal = -1;
        GameObject.Destroy(GameObject.FindObjectOfType<Animal>().gameObject);
    }
}
