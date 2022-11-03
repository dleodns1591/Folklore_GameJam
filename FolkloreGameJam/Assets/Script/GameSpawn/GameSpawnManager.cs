using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    public static GameSpawnManager Inst;
    void Awake() => Inst = this;

    public List<GameObject> gameSpawner = new List<GameObject>();
    public List<GameObject> gameSpawnBox = new List<GameObject>();

    public GameObject Canvas;

    [Header("다트")]
    public bool isPushCheck;

    [Header("제기차기")]
    public float pointSpeed;
    public bool isClickCheck;
    public bool isJegiSummon;

    [Header("줄다리기")]
    public float enemySpped;
    public float mySpeed;
    public bool isLineSummon;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Game_Summon()
    {
        isJegiSummon = false;
        isPushCheck = false;
        isClickCheck = false;

        Instantiate(gameSpawner[Random.Range(0, gameSpawner.Count)], transform.position, Quaternion.identity, Canvas.transform);
    }
}