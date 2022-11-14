using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    public int CollectPrize { get; set; }
    public float CollectTime { get; set; }
    public int CurrentFaze { get; set; }
    
}
