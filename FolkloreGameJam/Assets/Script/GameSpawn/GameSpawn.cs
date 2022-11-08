using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

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

    public GameObject loseCheck;

    [Header("���� : ��Ʈ")]
    public GameObject dartGame;
    public GameObject dartTarget;
    public GameObject gameTitleBackGround;

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

                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);

                yield return new WaitForSeconds(15f);
                SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);

                loseCheck.SetActive(true);
                Time.timeScale = 0;
                DOTween.KillAll();
                yield return new WaitForSecondsRealtime(1f);
                SceneManager.LoadScene("Title");

                break;
            #endregion

            #region ��������
            case EGame.EJegichagi:

                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isJegiSummon = true;
                jegiPoint.transform.DOLocalMoveX(-pointPos, GameSpawnManager.Inst.jegiPointSpeed * GameManager.Inst.everySpeed).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);

                yield return new WaitForSeconds(15f);
                SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);

                loseCheck.SetActive(true);
                Time.timeScale = 0;
                DOTween.KillAll();
                yield return new WaitForSecondsRealtime(1f);
                SceneManager.LoadScene("Title");

                break;
            #endregion

            #region �ٴٸ���
            case EGame.ETugofwar:
                yield return new WaitForSeconds(2f);
                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isLineSummon = true;

                yield return new WaitForSeconds(15f);
                SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);

                loseCheck.SetActive(true);
                Time.timeScale = 0;
                DOTween.KillAll();
                yield return new WaitForSecondsRealtime(1f);
                SceneManager.LoadScene("Title");
                break;
            #endregion

            case EGame.EDarumaOtoshi:

                yield return new WaitForSeconds(2f);

                gameTitleBackGround.SetActive(false);
                GameSpawnManager.Inst.isPieceSummon = true;
                hammerPoint.transform.DOLocalMoveX(-pointPos, GameSpawnManager.Inst.piecePointSpeed * GameManager.Inst.everySpeed).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);

                yield return new WaitForSeconds(15f);
                SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);

                loseCheck.SetActive(true);
                Time.timeScale = 0;
                DOTween.KillAll();
                yield return new WaitForSecondsRealtime(1f);
                SceneManager.LoadScene("Title");
                break;
        }
    }
}
