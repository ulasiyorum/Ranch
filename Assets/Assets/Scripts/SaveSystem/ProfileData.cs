using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProfileData
{
    public int Crop { get; private set; }
    public int Balance { get; private set; }
    public int ExtraCrop { get; private set; }

    public ProfileData(int balance,int extraCrop,int crop)
    {
        this.Balance = balance;
        this.ExtraCrop = extraCrop;
        this.Crop = crop;
    }
}
