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
        ETugofwar,
        EDarumaOtoshi,
    }
    public EGame eGame;

    [Header("���� : ��Ʈ")]
    public GameObject dartGame;
    public GameObject dartTarget;
    public GameObject gameTitleBackGround;

    public TextMeshProUGUI descriptionText;

    public Rigidbody2D dartRigidbody2D;

    [Header("���� : ��������")]
    public GameObject jegiPoint;

    [Header("���� : �ٷ縶�����")]
    public List<GameObject> randomPiece = new List<GameObject>();
    public GameObject hammerPoint;

    void Start()
    {
        StartCoroutine(MainGame());
    }

    void Update()
    {

    }

    IEnumerator MainGame()
    {
        int pointPos = 60;

        switch (eGame)
        {
            #region ��Ʈ
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

                Instantiate(dartTarget, new Vector2(posXRandom, posYRandom), Quaternion.identity, dartGame.transform);
                break;
            #endregion

            #region ��������
            case EGame.EJegichagi:

                descriptionText.text = "Jegichagi";
                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isJegiSummon = true;
                jegiPoint.transform.DOLocalMoveX(-pointPos, GameSpawnManager.Inst.jegiPointSpeed).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
                break;
            #endregion

            #region �ٴٸ���
            case EGame.ETugofwar:
                descriptionText.text = "Tugofwar";
                yield return new WaitForSeconds(2f);
                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isLineSummon = true;
                break;
            #endregion

            case EGame.EDarumaOtoshi:

                descriptionText.text = "DarumaOtoshi";
                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isPieceSummon = true;
                hammerPoint.transform.DOLocalMoveX(-pointPos, GameSpawnManager.Inst.piecePointSpeed).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}
