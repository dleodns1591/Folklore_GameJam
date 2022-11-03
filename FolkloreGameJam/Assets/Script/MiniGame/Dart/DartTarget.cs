using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DartTarget : MonoBehaviour, IPointerClickHandler
{

    [Header("다트 핀")]
    public GameObject dartPin;

    [Header("속도")]
    public int speed;

    Rigidbody2D rigidbody2D;
    Vector3 point;

    void Start()
    {
        Time.timeScale = 1;
        rigidbody2D = GetComponent<Rigidbody2D>();

        DartMove();
    }

    void Update()
    {
        MousePosition();
    }

    void DartMove()
    {
        float minY = -2.48f;
        float maxY = 2.48f;

        float minX = -2.84f;
        float maxX = 2.84f;
        switch (Random.Range(0, 3))
        {

            case 0:
                Debug.Log("왼쪽");
                float rightPosX = -2.84f;

                rigidbody2D.AddForce(new Vector2(rightPosX, Random.Range(minY, maxY)) * speed);
                break;

            case 1:
                Debug.Log("오른쪽");
                float leftPosX = 2.84f;

                rigidbody2D.AddForce(new Vector2(leftPosX, Random.Range(minY, maxY)) * speed);
                break;

            case 2:
                Debug.Log("아래");
                float bottomPosY = -2.48f;

                rigidbody2D.AddForce(new Vector2(Random.Range(minX, maxX), bottomPosY) * speed);
                break;

            case 3:
                Debug.Log("위");
                float topPosY = 2.48f;

                rigidbody2D.AddForce(new Vector2(Random.Range(minX, maxX), topPosY) * speed);
                break;
        }
    }

    void MousePosition()
    {
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                           Input.mousePosition.y,
                                                           -Camera.main.transform.position.z));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Pin_Summon());
    }

    public IEnumerator Pin_Summon()
    {
        float waitTime = 1f;

        if (GameSpawnManager.Inst.isPushCheck == false)
        {
            GameSpawnManager.Inst.isPushCheck = true;
            Instantiate(dartPin, point, Quaternion.identity).transform.parent = gameObject.transform;
            Time.timeScale = 0;

            Debug.Log("Win");

            yield return new WaitForSecondsRealtime(waitTime);
            Destroy(transform.parent.gameObject);
            GameSpawnManager.Inst.Game_Summon();
        }
    }
}
