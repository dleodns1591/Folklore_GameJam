using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    void Awake() => Inst = this;

    public int everySpeed;

    public bool isflashingEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
