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
    public bool isPushCheck;

    void Start()
    {
        Game_Summon();
    }

    void Update()
    {

    }

    public void Game_Summon()
    {
        Instantiate(gameSpawner[Random.Range(0, gameSpawner.Count)], transform.position, Quaternion.identity, Canvas.transform);
    }
}