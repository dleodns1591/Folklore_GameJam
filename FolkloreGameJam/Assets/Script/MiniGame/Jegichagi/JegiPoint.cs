using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class JegiPoint : MonoBehaviour
{
    public GameObject winCheck;
    public GameObject loseCheck;

    [Header("주요요소")]
    public GameObject jegi;
    public GameObject timingRange;
    public GameObject timingBar;
    public GameObject jegichagiGame;

    Rigidbody2D jegiRegidbody2D;
    [SerializeField] const float timingRangeX = 160;

    [Header("플레이어")]
    public GameObject playerNotKick;
    public GameObject playerKick;

    public bool isCheck;
    public bool isLoseCheck;
    public bool isCollisionCheck;

    void Start()
    {
        Time.timeScale = 1;

        jegiRegidbody2D = jegi.GetComponent<Rigidbody2D>();
        TimingRange_Move();
    }

    void Update()
    {
        if (GameManager.Inst.isScreenDownCheck == true)
            Point_MouseEvent();
    }

    void TimingRange_Move() => timingRange.transform.DOLocalMoveX(Random.Range(-timingRangeX, timingRangeX), 0);

    void Point_MouseEvent()
    {
        if (Input.GetMouseButtonDown(0) && GameSpawnManager.Inst.isJegiClickCheck == false && GameSpawnManager.Inst.isJegiSummon == true)
        {
            SoundManager.instance.PlaySoundClip("kick", SoundType.SFX, 10f);
            GameSpawnManager.Inst.isJegiClickCheck = true;
            transform.DOKill();
        }
    }

    IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TimingIn"))
        {
            isCollisionCheck = true;

            if (GameSpawnManager.Inst.isJegiClickCheck == true && isCheck == false && isCollisionCheck == true)
            {
                SoundManager.instance.PlaySoundClip("success", SoundType.SFX, 10f);
                winCheck.SetActive(true);

                isCheck = true;
                playerNotKick.SetActive(false);
                playerKick.SetActive(true);

                jegi.transform.DOLocalMoveY(-85, 0);

                yield return new WaitForSeconds(1);
                Time.timeScale = 0;
                Destroy(jegichagiGame);

                GameSpawnManager.Inst.Game_Summon();
            }

        }

        if (collision.CompareTag("TimingOut"))
        {
            if (GameSpawnManager.Inst.isJegiClickCheck == true && isCheck == false && isCollisionCheck == false)
            {
                SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);
                loseCheck.SetActive(true); 
                isCheck = true;

                jegi.transform.DOLocalMoveY(-250, 0);
                jegi.transform.DORotate(new Vector3(0, 0, 33), 0);

                yield return new WaitForSeconds(1);
                GameManager.Inst.Initialization();
                SceneManager.LoadScene("Title");
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TimingIn"))
            isCollisionCheck = false;
    }
}
