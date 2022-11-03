using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HammerPoint : MonoBehaviour
{
    [Header("주요요소")]
    public GameObject timingRange;
    public GameObject timingBar;
    public GameObject darumaOtoshi_Game;
    public GameObject hammer;

    public int hammerRot = 25;
    [SerializeField] const float timingRangeX = 160;

    int clearCount = 0;
    Rigidbody2D jegiRegidbody2D;

    bool isCheck;
    bool isLoseCheck;
    bool isCollisionCheck;

    void Start()
    {
        Time.timeScale = 1;

        TimingRange_Move();
    }

    void Update()
    {
        Point_MouseEvent();
    }

    void TimingRange_Move() => timingRange.transform.DOLocalMoveX(Random.Range(-timingRangeX, timingRangeX), 0);

    void Point_MouseEvent()
    {
        if (Input.GetMouseButtonDown(0) && GameSpawnManager.Inst.isPieceClickCheck == false && GameSpawnManager.Inst.isPieceSummon == true)
        {
            GameSpawnManager.Inst.isPieceClickCheck = true;
        }
    }

    void BoolValue()
    {
        isCheck = false;
        isLoseCheck = false;
        isCollisionCheck = false;

        GameSpawnManager.Inst.isPieceClickCheck = false;
    }

    IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        Sequence sequence = DOTween.Sequence();
        float waitTime = 0.4f;

        if (collision.CompareTag("TimingIn"))
        {
            isCollisionCheck = true;

            if (GameSpawnManager.Inst.isPieceClickCheck == true && isCheck == false && isCollisionCheck == true)
            {
                isCheck = true;
                clearCount++;
                hammer.transform.DORotate(new Vector3(0, 0, hammerRot), waitTime);
                yield return new WaitForSeconds(waitTime);
                hammer.transform.DORotate(new Vector3(0, 0, -hammerRot), waitTime);
                yield return new WaitForSeconds(waitTime);
                hammer.transform.DORotate(new Vector3(0, 0, 0), waitTime);
                if (clearCount < 6)
                {
                    Debug.Log("다음");
                    BoolValue();
                }
                
                else
                {
                    Debug.Log("승리");
                    yield return new WaitForSeconds(1f);
                    Time.timeScale = 0;
                    Destroy(darumaOtoshi_Game);

                    GameSpawnManager.Inst.Game_Summon();
                }
            }

        }

        if (collision.CompareTag("TimingOut"))
        {
            if (GameSpawnManager.Inst.isPieceClickCheck == true && isCheck == false && isCollisionCheck == false)
            {
                Debug.Log("패배");
                isCheck = true;

                yield return new WaitForSeconds(1);
                Time.timeScale = 0;
                Destroy(darumaOtoshi_Game);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TimingIn"))
            isCollisionCheck = false;
    }
}
