using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSpawn : MonoBehaviour
{
    public enum EGame
    {
        EDart,
        EJegichagi,
    }
    public EGame eGame;

    [Header("게임 : 다트")]
    public GameObject dartTarget;
    public GameObject gameTitleBackGround;

    public TextMeshProUGUI descriptionText;

    public Rigidbody2D dartRigidbody2D;

    void Start()
    {
        StartCoroutine(MainGame());
    }

    void Update()
    {
        
    }

    IEnumerator MainGame()
    {
        switch (eGame)
        {
            case EGame.EDart:
                float minX = -2;
                float maxX = 3;
                float minY = 1f;
                float maxY = -3f;

                float posXRandom = Random.Range(minX, maxX);
                float posYRandom = Random.Range(minY, maxY);

                descriptionText.text = "Dart";

                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);

                Instantiate(dartTarget, new Vector2(posXRandom, posYRandom), Quaternion.identity).transform.parent = gameObject.transform;
                break;
        }
    }
}
