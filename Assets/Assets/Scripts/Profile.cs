using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Profile
{
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

    private static int extraCrop = 0;

    //////
    
    private static void Load() // send value
    {
        balance = 0;
        extraCrop = 0;
    }
}
