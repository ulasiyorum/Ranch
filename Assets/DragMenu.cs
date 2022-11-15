using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMenu : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerDownHandler
{
    public Canvas canvas;
    private RectTransform rect;
    private float limit;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        limit = rect.anchoredPosition.y;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponentInChildren<RectTransform>().anchoredPosition.y > limit + 500) return;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + eventData.delta.y / canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetComponentInChildren<RectTransform>().anchoredPosition.y >= limit + 200)
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, limit + 500);
        else
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, limit);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
