using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class battery : MonoBehaviour
{
    Slider max_battery;
    float fSliderBarTime;
    void Start()
    {
        max_battery = GetComponent<Slider>();
    }

    void Update()
    {
        if (max_battery.value > 10f)
        {
            max_battery.value -= Time.deltaTime;
        }
        else
        {
            Debug.Log("battery Zero.");
        }
    }
}
