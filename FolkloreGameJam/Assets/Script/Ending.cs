using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI reGameRenderer;
    public Button reGameBtn;

    void Start()
    {
        SoundManager.instance.PlaySoundClip("BGM", SoundType.BGM, 1f);

        reGameBtn.onClick.AddListener(() =>
        {
            reGameRenderer.transform.DOKill();
            SceneManager.LoadScene("Title");
        });


        StartCoroutine(EndingCheck());
    }

    void Update()
    {
        
    }

    IEnumerator EndingCheck()
    {
        yield return new WaitForSeconds(3);
        reGameRenderer.DOFade(1, 0.5f);
    }

    
}
