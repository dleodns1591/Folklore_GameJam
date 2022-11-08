using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DartTarget : MonoBehaviour, IPointerClickHandler
{

    [Header("��Ʈ ��")]
    public GameObject dartGmae;
    public GameObject dartPin;

    [Header("�ӵ�")]
    public int speed;

    public GameObject winCheck;
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
                Debug.Log("����");
                float rightPosX = -2.84f;

                rigidbody2D.AddForce(new Vector2(rightPosX, Random.Range(minY, maxY)) * (speed * GameManager.Inst.everySpeed));
                break;

            case 1:
                Debug.Log("������");
                float leftPosX = 2.84f;

                rigidbody2D.AddForce(new Vector2(leftPosX, Random.Range(minY, maxY)) * (speed * GameManager.Inst.everySpeed));
                break;

            case 2:
                Debug.Log("�Ʒ�");
                float bottomPosY = -2.48f;

                rigidbody2D.AddForce(new Vector2(Random.Range(minX, maxX), bottomPosY) * (speed * GameManager.Inst.everySpeed));
                break;

            case 3:
                Debug.Log("��");
                float topPosY = 2.48f;

                rigidbody2D.AddForce(new Vector2(Random.Range(minX, maxX), topPosY) * (speed * GameManager.Inst.everySpeed));
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
        SoundManager.instance.PlaySoundClip("Darts", SoundType.SFX, 10f);
    }

    public IEnumerator Pin_Summon()
    {
        float waitTime = 1f;

        if (GameSpawnManager.Inst.isPushCheck == false)
        {
            GameSpawnManager.Inst.isPushCheck = true;
            Instantiate(dartPin, point, Quaternion.identity).transform.parent = gameObject.transform;
            Time.timeScale = 0;

            winCheck.SetActive(true);
            SoundManager.instance.PlaySoundClip("success", SoundType.SFX, 10f);

            yield return new WaitForSecondsRealtime(waitTime);
            Destroy(transform.parent.gameObject);
            GameSpawnManager.Inst.Game_Summon();
        }
    }
}
