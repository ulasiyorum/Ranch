using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProfileData
{
    public int Animal { get; private set; }
    public int Crop { get; private set; }
    public int Balance { get; private set; }
    public int ExtraCrop { get; private set; }
    public int RegrowFaster { get; private set; }

    public int[] UpgradesPriceList { get; private set; }

    public ProfileData()
    {
        this.Balance = Profile.Balance;
        this.ExtraCrop = Profile.ExtraCrop;
        this.Crop = Profile.Crop.ID;
        this.RegrowFaster = Profile.RegrowFaster;
        this.UpgradesPriceList = Profile.PriceList;
        this.Animal = Profile.Animal;
    }
}
