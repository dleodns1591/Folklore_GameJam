using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tugofwar : MonoBehaviour
{
    public GameObject tugofwarGame;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (GameSpawnManager.Inst.isLineSummon == true)
        {
            MyMove();
            EnemyMove();
        }
    }

    void MyMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float fMove = Time.deltaTime * GameSpawnManager.Inst.mySpeed;
            transform.Translate(Vector3.left * fMove);
        }
    }

    void EnemyMove()
    {
        float fMove = Time.deltaTime * GameSpawnManager.Inst.enemySpped;
        transform.Translate(Vector3.right * fMove);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tugofwar_Win"))
        {
            Debug.Log("½Â¸®");
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(1);

            Destroy(tugofwarGame);
            GameSpawnManager.Inst.Game_Summon();
        }

        if (collision.CompareTag("Tugofwar_Lose"))
        {
            Debug.Log("ÆÐ¹è");

            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(1);

            Destroy(tugofwarGame);
        }
    }

}
