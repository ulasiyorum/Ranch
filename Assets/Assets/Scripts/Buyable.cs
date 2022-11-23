using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable
{
    public int Price { get; set; }
    public int ID { get; set; }
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
            _ => null
        };
    }
    public Buyable()
    {
 
    }
    public static Buyable GetBuyable(int buy) => buy switch
    {
        0 => new Buyable(),
        1 => new Buyable(),
        2 => new Buyable(),
        _ => null
    };

    public static void Event0(GameAssets assets)
    {
        ClearAnimals();
        GameObject.Instantiate(assets.AnimalPrefabs[0],GameObject.FindObjectOfType<Canvas>().transform,false);
    }
    public static void Event1(GameAssets assets)
    {
        ClearAnimals();
        GameObject.Instantiate(assets.AnimalPrefabs[1], GameObject.FindObjectOfType<Canvas>().transform, false);
    }
    // Shop is planned to have more things than just animals so that's why it's implemented like this : It's not finished
    public static void ClearAnimals()
    {
        GameObject.Destroy(GameObject.FindObjectOfType<Animal>());
    }
}
