using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    float waitTime = 0.5f;

    [Header("메인")]
    public GameObject mainWindow;
    public GameObject blackScreen;

    public Button playBtn;
    public Button optionBtn;
    public Button extrasBtn;

    [Header("설정")]
    public GameObject optionWindow;

    public GameObject screenShake;
    public GameObject flashingEffect;

    public TextMeshProUGUI screenShakeValue;
    public TextMeshProUGUI flashingEffectOnOff;

    public Button optionBackBtn;
    public Button screenShakeBtn; // 화면 흔들림 효과 버튼
    public Button flashingEffectBtn; // 깜빡임 효과 버튼

    [Header("크레딧")]
    public GameObject extrasWindow;

    public Button extrasBackBtn;

    [Header("인게임")]
    public GameObject inGameWindow;
    public GameObject title;

    void Start()
    {
        Main_Btns();
        Option_Btns();
        Extras_Btn();
    }

    void Update()
    {
        
    }

    #region 메인버튼 이벤트
    void Main_Btns()
    {
        float waitTime = 0.5f;
        int mainExtrasWindowPos = 1050;
        int mainOptionWindowPos = -1800;

        // 플레이 버튼을 눌렀을 때
        playBtn.onClick.AddListener(() =>
        {
            StartCoroutine(GameStart());
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

    public IEnumerator GameStart()
    {
        int rightMovePos = 1960;
        Sequence sequence = DOTween.Sequence();

        blackScreen.transform.DOLocalMoveX(0, waitTime);
        inGameWindow.transform.DOLocalMoveX(0, waitTime);

        yield return new WaitForSeconds(2);

        mainWindow.transform.DOLocalMoveX(rightMovePos, waitTime);
        blackScreen.transform.DOLocalMoveX(rightMovePos, waitTime);
        sequence.Append(title.transform.DOLocalMoveX(0, waitTime));

        yield return new WaitForSeconds(1);
        title.transform.DOLocalMoveY(700, waitTime);

        yield return new WaitForSeconds(waitTime);

        GameSpawnManager.Inst.Game_Summon();
    }

    public void PlayBtn_Enter()
    {
        playBtn.transform.DOLocalMoveX(0, waitTime);
    }

    public void PlayBtn_Exit()
    {
        int movePos = -57;

        playBtn.transform.DOLocalMoveX(movePos, waitTime);
    }

    public void OptionBtn_Enter()
    {
        optionBtn.transform.DOLocalMoveX(0, waitTime);
    }

    public void OptionBtn_Exit()
    {
        int movePos = -57;
        optionBtn.transform.DOLocalMoveX(movePos, waitTime);
    }   

    public void ExtraBtn_Enter()
    {
        extrasBtn.transform.DOLocalMoveX(0, waitTime);
    }

    public void ExtraBtn_Exit()
    {
        int movePos = -57;
        extrasBtn.transform.DOLocalMoveX(movePos, waitTime);
    }
    #endregion

    #region 설정버튼 이벤트
    void Option_Btns()
    {
        int optionWindowPos = 1940;

        // 깜빡임효과 버튼을 눌렀을 때
        flashingEffectBtn.onClick.AddListener(() =>
        {
            if (GameManager.Inst.isflashingEffect == false)
            {
                GameManager.Inst.isflashingEffect = true;
                flashingEffectOnOff.text = "ON";
            }
            else
            {
                GameManager.Inst.isflashingEffect = false;
                flashingEffectOnOff.text = "OFF";
            }

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

    public void ScreenShakeBtn_Enter()
    {
        int movePos = 70;

        screenShake.transform.DOLocalMoveX(movePos, waitTime);
    }

    public void ScreenShakeBtn_Exit()
    {
        screenShake.transform.DOLocalMoveX(0, waitTime);
    }

    public void FlashingEffectBtn_Enter()
    {
        int movePos = 70;

        flashingEffect.transform.DOLocalMoveX(movePos, waitTime);
    }

    public void FlashingEffectBtn_Exit()
    {
        flashingEffect.transform.DOLocalMoveX(0, waitTime);
    }
    #endregion

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
