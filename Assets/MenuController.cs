using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class MenuController : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject _menu;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_menu == null) return;
        _menu.SetActive(!_menu.activeInHierarchy);
    }

   
}
