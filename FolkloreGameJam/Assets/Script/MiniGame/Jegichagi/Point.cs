using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Point : MonoBehaviour
{
    [Header("제기")]
    public GameObject jegi;

    [Header("다리")]
    public GameObject leg;

    bool isCheck;
    bool isWinCheck;
    bool isLoseChekc;

    void Start()
    {

    }

    void Update()
    {
        Point_MouseEvent();
        JegiMove();
    }

    void JegiMove()
    {
        Vector2 legPos = new Vector2(30, -40);
        Vector3 legRot = new Vector3(0, 0, -90);

        if (GameSpawnManager.Inst.isClickCheck == true)
        {
            if (isWinCheck == false)
            {
                Debug.Log("실패");
            }

            else
            {
                leg.transform.DOLocalMove(legPos, 0);
                leg.transform.DORotate(legRot, 0);
            }
        }
    }

    void Point_MouseEvent()
    {
        if (Input.GetMouseButtonDown(0) && GameSpawnManager.Inst.isClickCheck == false)
        {
            GameSpawnManager.Inst.isClickCheck = true;
            transform.DOKill();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TimingIn") && GameSpawnManager.Inst.isClickCheck == true && isCheck == false)
        {
            isCheck = true;
            isWinCheck = true;
        }
    }
}
