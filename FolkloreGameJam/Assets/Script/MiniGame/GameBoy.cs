using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GameBoy : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public GameObject gameBoy;

    int gameBoyPos = 970;
    float waitTime = 0.5f;
    bool isClickCheck;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isClickCheck == false)
            gameBoy.transform.DOLocalMoveY(-gameBoyPos, waitTime).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isClickCheck == false)
            gameBoy.transform.DOLocalMoveY(-1045, waitTime).SetUpdate(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isClickCheck = true;
        gameBoy.transform.DOLocalMoveY(0, waitTime).SetUpdate(true)
               .OnComplete(() =>
               {
                   isClickCheck = false;
                   Time.timeScale = 1;
               });
    }
}
