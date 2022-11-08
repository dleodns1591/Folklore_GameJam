using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    float waitTime = 0.5f;

    public GameObject loseCheck;

    [Header("����")]
    public GameObject mainWindow;
    public GameObject blackScreen;

    public Button playBtn;
    public Button optionBtn;
    public Button extrasBtn;

    bool batterStart = false;
    bool timerStart = false;

    [Header("����")]
    public GameObject optionWindow;

    public GameObject screenShake;
    public GameObject flashingEffect;

    public TextMeshProUGUI screenShakeValue;
    public TextMeshProUGUI flashingEffectOnOff;

    public Button optionBackBtn;
    public Button screenShakeBtn; // ȭ�� ��鸲 ȿ�� ��ư
    public Button flashingEffectBtn; // ������ ȿ�� ��ư

    [Header("ũ����")]
    public GameObject extrasWindow;

    public Button extrasBackBtn;

    [Header("�ΰ���")]
    public GameObject title;
    public GameObject inGameWindow;
    public GameObject gameBoy;

    public Slider batterySlider;

    public Button chargerBtn;
    public Button chargerClickBtn;

    public TextMeshProUGUI[] timeText;
    public float time = 300;
    public int min, sec;
    float batterySpeed = 1;

    void Start()
    {
        Time.timeScale = 1;

        timeText[0].text = "05";
        timeText[1].text = "00";

        Main_Btns();
        Option_Btns();
        Extras_Btn();
        Ingmae_Btn();

    }

    void Update()
    {
        Timer();
        StartCoroutine(Battery());
    }

    #region ���ι�ư �̺�Ʈ
    void Main_Btns()
    {
        float waitTime = 0.5f;
        int mainExtrasWindowPos = 1050;
        int mainOptionWindowPos = -1800;

        // �÷��� ��ư�� ������ ��
        playBtn.onClick.AddListener(() =>
        {
            StartCoroutine(GameStart());
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

    public IEnumerator GameStart()
    {
        int rightMovePos = 1960;
        Sequence sequence = DOTween.Sequence();

        blackScreen.transform.DOLocalMoveX(0, waitTime);
        inGameWindow.transform.DOLocalMoveX(0, 2);

        yield return new WaitForSeconds(2);

        mainWindow.transform.DOLocalMoveX(rightMovePos, waitTime);
        blackScreen.transform.DOLocalMoveX(rightMovePos, waitTime);
        sequence.Append(title.transform.DOLocalMoveX(0, 2));

        batterStart = true;

        yield return new WaitForSeconds(2);
        title.transform.DOLocalMoveY(700, 2);

        yield return new WaitForSeconds(2);

        timerStart = true;
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

    #region ������ư �̺�Ʈ
    void Option_Btns()
    {
        int optionWindowPos = 1940;

        // ������ȿ�� ��ư�� ������ ��
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
        int extrasWindowPos = -1100;

        // �ڷΰ��� ��ư�� ������ ��
        extrasBackBtn.onClick.AddListener(() =>
        {
            mainWindow.transform.DOLocalMoveY(0, waitTime);
            extrasWindow.transform.DOLocalMoveY(extrasWindowPos, waitTime);
        });
    }

    void Ingmae_Btn()
    {
        // ������ ��ư�� ������ ��
        chargerBtn.onClick.AddListener(() =>
        {
            int gmaeBoyPos = 1045;
            gameBoy.transform.DOLocalMoveY(-gmaeBoyPos, waitTime).SetUpdate(true);
            Time.timeScale = 0;
        });

        // Ŭ���� ������ ��ư�� ������ ��
        chargerClickBtn.onClick.AddListener(() =>
        {
            batterySlider.value += 10;
        });
    }

    public IEnumerator Battery()
    {
        if (min == 3)
            batterySpeed *= GameManager.Inst.everySpeed;

        if (batterStart == true)
        {

            if (batterySlider.value > 0)
                batterySlider.value -= batterySpeed * Time.unscaledDeltaTime;

            else if(batterySlider.value <= 0)
            {
                loseCheck.SetActive(true);

                yield return new WaitForSeconds(1);

                Time.timeScale = 0;
                SceneManager.LoadScene("Title");
            }
        }
    }

    public void Timer()
    {
        switch (min)
        {
            case 3:
                GameManager.Inst.everySpeed = 0.8f;
                break;

            case 1:
                SoundManager.instance.PlaySoundClip("LastTime", SoundType.BGM, 1f);
                GameManager.Inst.everySpeed = 0.6f;
                break;
        }


        if (timerStart == true)
        {
            time -= Time.deltaTime;

            min = (int)time / 60;
            sec = ((int)time - min * 60) % 60;

            if (min <= 0 && sec <= 0)
            {
                timeText[0].text = 0.ToString();
                timeText[1].text = 0.ToString();

                SceneManager.LoadScene("Ending");
            }

            else
            {
                if (sec >= 60)
                {
                    min += 1;
                    sec -= 60;
                }

                else
                {
                    timeText[0].text = min.ToString();
                    timeText[1].text = sec.ToString();
                }
            }
        }
    }

}
