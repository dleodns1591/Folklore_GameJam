using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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

    [Header("게임 : 제기차기")]
    public GameObject point;

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
            #region 다트
            case EGame.EDart:
                float minY = -2.48f;
                float maxY = 2.48f;

                float minX = -2.84f;
                float maxX = 2.84f;

                float posXRandom = Random.Range(minX, maxX);
                float posYRandom = Random.Range(minY, maxY);

                descriptionText.text = "Dart";
                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);

                Instantiate(dartTarget, new Vector2(posXRandom, posYRandom), Quaternion.identity).transform.parent = gameObject.transform;
                break;
            #endregion

            case EGame.EJegichagi:
                int pointPos = 94;

                //descriptionText.text = "Jegichagi";
                //yield return new WaitForSeconds(2f);

                //gameTitleBackGround.SetActive(false);
                point.transform.DOLocalMoveX(pointPos, 2f).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}
