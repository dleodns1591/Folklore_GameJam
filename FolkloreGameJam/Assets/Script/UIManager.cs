using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("메인")]
    public GameObject mainWindow;

    public Button playBtn;
    public Button optionBtn;
    public Button extrasBtn;

    [Header("설정")]
    public GameObject optionWindow;

    public Button optionBackBtn;
    public Button flashingEffectBtn; // 깜빡임 효과 버튼
    public Button screenShakeBtn; // 화면 흔들림 효과 버튼

    [Header("크레딧")]
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

        // 플레이 버튼을 눌렀을 때
        playBtn.onClick.AddListener(() =>
        {

        });

        // 설정 버튼을 눌렀을 때
        optionBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveX(mainOptionWindowPos, waitTime);
            optionWindow.transform.DOLocalMoveX(0, waitTime);
        });


        // 크레딧 버튼을 눌렀을 때
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

        // 깜빡임효과 버튼을 눌렀을 때
        flashingEffectBtn.onClick.AddListener(() =>
        {

        });

        // 화면 흔들림 효과 버튼을 눌렀을 때
        screenShakeBtn.onClick.AddListener(() =>
        {

        });

        // 뒤로가기 버튼을 눌렀을 때
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

        // 뒤로가기 버튼을 눌렀을 때
        extrasBackBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveY(0, waitTime);
            extrasWindow.transform.DOLocalMoveY(extrasWindowPos, waitTime);
        });
    }
}
