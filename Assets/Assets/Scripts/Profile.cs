using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Profile
{
    private static Crop crop;
    public static Crop Crop { 
        get 
        {
            if (crop == null) 
                return new Crop(0);
            else
                return crop;
        } 
    }
    private static int animal = -1;
    public static int Animal
    {
        get => animal;
        set => animal = value;
    }
    private static int balance;
    public static int Balance 
    { 
        get => balance; 
        set 
        { 
            if (value < 0) 
                return; 
            balance = value; 
        } 
    }
    public static int ExtraCrop
    {
        get => extraCrop;
        set
        {
            if (value < 0)
                return;
            extraCrop = value;
        }
    }
    public static int RegrowFaster
    {
        get => regrowFaster;
        set
        {
            if (value < 0)
                return;
            regrowFaster = value;
        }
    }
    //////

    private static int extraCrop;
    private static int regrowFaster;

    //////
    private static int[] priceList = new int[10] { 10, 25, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] PriceList { get => priceList; set => priceList = value; }

    public static void Load(ProfileData p) // send value
    {
        balance = p.Balance;
        extraCrop = p.ExtraCrop;
        crop = new Crop(p.Crop);
        regrowFaster = p.RegrowFaster;
        PriceList = p.UpgradesPriceList;
        animal = p.Animal;
    }
}
