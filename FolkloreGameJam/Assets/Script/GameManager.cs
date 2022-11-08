using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    void Awake() => Inst = this;

    [Header("전체 속도")]
    public float everySpeed;

    [Header("게임기")]
    public bool isScreenDownCheck;

    [Header("설정 값")]
    public bool isflashingEffect;


    void Start()
    {
        SoundManager.instance.PlaySoundClip("BGM", SoundType.BGM, 1f);
    }

    void Update()
    {

    }

    public void Initialization()
    {
        everySpeed = 1;

        GameSpawnManager.Inst.isPushCheck = false;

        GameSpawnManager.Inst.isJegiSummon = false;
        GameSpawnManager.Inst.isJegiClickCheck = false;

        GameSpawnManager.Inst.isLineSummon = false;

        GameSpawnManager.Inst.isPieceSummon = false;
        GameSpawnManager.Inst.isPieceClickCheck = false;
    }
}
