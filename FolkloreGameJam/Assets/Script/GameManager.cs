using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    void Awake() => Inst = this;

    [Header("��ü �ӵ�")]
    public float everySpeed;

    [Header("���ӱ�")]
    public bool isScreenDownCheck;

    [Header("���� ��")]
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
