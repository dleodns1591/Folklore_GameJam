using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DartTarget : MonoBehaviour
{
    public GameObject dartPin;

    public Rigidbody2D rigidbody2D;
    public int speed;

    Vector3 point;

    void Start()
    {
        Time.timeScale = 1;

        DartMove();
    }

    void Update()
    {
        MousePosition();
    }

    void DartMove()
    {
        float minX = -2;
        float maxX = 3;
        float minY = 1f;
        float maxY = -3f;

        float posXRandom = Random.Range(minX, maxX);
        float posYRandom = Random.Range(minY, maxY);

        rigidbody2D.AddForce(new Vector2(posXRandom, posYRandom) * speed);
    }

    void MousePosition()
    {
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                           Input.mousePosition.y,
                                                           -Camera.main.transform.position.z));
    }

    public void OnMouseDown()
    {
        StartCoroutine(Pin_Summon());
    }

    public IEnumerator Pin_Summon()
    {
        float waitTime = 0.5f;

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
