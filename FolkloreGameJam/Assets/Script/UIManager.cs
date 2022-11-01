using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("����")]
    public GameObject mainWindow;

    public Button playBtn;
    public Button optionBtn;
    public Button extrasBtn;

    [Header("����")]
    public GameObject optionWindow;

    public Button optionBackBtn;
    public Button flashingEffectBtn; // ������ ȿ�� ��ư
    public Button screenShakeBtn; // ȭ�� ��鸲 ȿ�� ��ư

    [Header("ũ����")]
    public GameObject extrasWindow;

    public Button extrasBackBtn;

    void Start()
    {
        Main_Btns();
        Option_Btns();
        Extras_Btn();
    }

    void Update()
    {
        
    }

    void Main_Btns()
    {
        float waitTime = 0.5f;
        int mainExtrasWindowPos = 1050;
        int mainOptionWindowPos = -1800;

        // �÷��� ��ư�� ������ ��
        playBtn.onClick.AddListener(() =>
        {

        });

        // ���� ��ư�� ������ ��
        optionBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveX(mainOptionWindowPos, waitTime);
            optionWindow.transform.DOLocalMoveX(0, waitTime);
        });


        // ũ���� ��ư�� ������ ��
        extrasBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveY(mainExtrasWindowPos, waitTime);
            extrasWindow.transform.DOLocalMoveY(0, 0.5f);
        });
    }

    void Option_Btns()
    {
        float waitTime = 0.5f;
        int optionWindowPos = 1940;

        // ������ȿ�� ��ư�� ������ ��
        flashingEffectBtn.onClick.AddListener(() =>
        {

        });

        // ȭ�� ��鸲 ȿ�� ��ư�� ������ ��
        screenShakeBtn.onClick.AddListener(() =>
        {

        });

        // �ڷΰ��� ��ư�� ������ ��
        optionBackBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveX(0, waitTime);
            optionWindow.transform.DOLocalMoveX(optionWindowPos, waitTime);
        });
    }

    void Extras_Btn()
    {
        float waitTime = 0.5f;
        int extrasWindowPos = -1100;

        // �ڷΰ��� ��ư�� ������ ��
        extrasBackBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveY(0, waitTime);
            extrasWindow.transform.DOLocalMoveY(extrasWindowPos, waitTime);
        });
    }
}
