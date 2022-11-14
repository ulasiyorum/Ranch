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

    //////

    private static int extraCrop;

    //////
    
    public static void Load(ProfileData p) // send value
    {
        balance = p.Balance;
        extraCrop = p.ExtraCrop;
        crop = new Crop(p.Crop);
    }
}
