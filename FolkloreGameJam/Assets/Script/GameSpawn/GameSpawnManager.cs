using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    public static GameSpawnManager Inst;
    void Awake() => Inst = this;

    public List<GameObject> gameSpawner = new List<GameObject>();
    public List<GameObject> gameSpawnBox = new List<GameObject>();

    public GameObject gameBoy;
    public GameObject ingameScreen;

    [Header("��Ʈ")]
    public bool isPushCheck;

    [Header("��������")]
    public float jegiPointSpeed;
    public bool isJegiClickCheck;
    public bool isJegiSummon;

    [Header("�ٴٸ���")]
    public float enemySpped;
    public float mySpeed;
    public bool isLineSummon;

    [Header("�ٷ縶�����")]
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