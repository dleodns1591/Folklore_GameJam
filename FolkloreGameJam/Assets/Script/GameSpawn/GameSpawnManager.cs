using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    public static GameSpawnManager Inst;
    void Awake() => Inst = this;

    public List<GameObject> gameSpawner = new List<GameObject>();

    public GameObject gameBoy;
    public GameObject ingameScreen;

    [Header("다트")]
    public bool isPushCheck;

    [Header("제기차기")]
    public float jegiPointSpeed;
    public bool isJegiClickCheck;
    public bool isJegiSummon;

    [Header("줄다리기")]
    public float enemySpped;
    public float mySpeed;
    public bool isLineSummon;

    [Header("다루마오토시")]
    public float piecePointSpeed;
    public bool isPieceClickCheck;
    public bool isPieceSummon;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Game_Summon()
    {
        BoolValue();
        Instantiate(gameSpawner[Random.Range(0, gameSpawner.Count)], ingameScreen.transform.position, Quaternion.identity, gameBoy.transform);
    }

    public void BoolValue()
    {
        isPushCheck = false;

        isJegiSummon = false;
        isJegiClickCheck = false;

        isLineSummon = false;

        isPieceSummon = false;
        isPieceClickCheck = false;
    }
}