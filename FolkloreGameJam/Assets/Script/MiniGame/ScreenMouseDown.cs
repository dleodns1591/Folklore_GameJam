using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenMouseDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData) =>
        GameManager.Inst.isScreenDownCheck = true;

    public void OnPointerExit(PointerEventData eventData) =>
        GameManager.Inst.isScreenDownCheck = false;
}
