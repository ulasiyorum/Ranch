using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICollectable
{
    public int ID { get; }
    public int PurchaseValue { get; }
    public int CollectPrize { get; }
    public float CollectTime { get; }
    public int CurrentFaze { get; }

    public IEnumerator SkipFaze(float collectTime);
}
