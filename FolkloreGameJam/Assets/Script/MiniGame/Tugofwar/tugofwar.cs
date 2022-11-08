using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tugofwar : MonoBehaviour
{
    public GameObject tugofwarGame;

    public GameObject winCheck;
    public GameObject loseCheck;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (GameSpawnManager.Inst.isLineSummon == true)
        {
            EnemyMove();
        }

        if(GameManager.Inst.isScreenDownCheck == true)
            MyMove();
    }

    void MyMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float fMove = Time.deltaTime * (GameSpawnManager.Inst.mySpeed * GameManager.Inst.everySpeed);
            transform.Translate(Vector3.left * fMove);
        }
    }

    void EnemyMove()
    {
        float fMove = Time.deltaTime * (GameSpawnManager.Inst.enemySpped * GameManager.Inst.everySpeed);
        transform.Translate(Vector3.right * fMove);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tugofwar_Win"))
        {
            SoundManager.instance.PlaySoundClip("success", SoundType.SFX, 10f);
            winCheck.SetActive(true);

            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(1);
            Destroy(tugofwarGame);
            GameSpawnManager.Inst.Game_Summon();
        }

        if (collision.CompareTag("Tugofwar_Lose"))
        {
            SoundManager.instance.PlaySoundClip("fail", SoundType.SFX, 10f);
            loseCheck.SetActive(true);

            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(1);

            GameManager.Inst.Initialization();
            SceneManager.LoadScene("Title");
        }
    }

}
