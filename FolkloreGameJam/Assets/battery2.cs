using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class battery2 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Slider max_battery;
    public void OnPointerClick(PointerEventData eventData)
    {


        max_battery.value += 10f;

    }
}
