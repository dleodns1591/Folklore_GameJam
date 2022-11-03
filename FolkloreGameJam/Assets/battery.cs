using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battery : MonoBehaviour
{
    public Slider batteryMax;

    void Start()
    {
    }

    void Update()
    {
        if (batteryMax.value > 10f)
        {
            batteryMax.value -= Time.deltaTime;
        }
        else
        {
            Debug.Log("battery Zero.");
        }
    }
}
