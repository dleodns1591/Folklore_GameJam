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

    [Header("게임 : 다트")]
    public GameObject dartGame;
    public GameObject dartTarget;
    public GameObject gameTitleBackGround;

    [Header("게임 : 제기차기")]
    public GameObject jegiPoint;

    [Header("게임 : 다루마오토시")]
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
            #region 다트
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

            #region 제기차기
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

            #region 줄다리기
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
