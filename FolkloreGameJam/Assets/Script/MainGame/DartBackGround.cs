using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DartBackGround : MonoBehaviour, IPointerClickHandler
{
    public GameObject dartPin;
    Vector3 point;

    void Start()
    {
        
    }

    void Update()
    {
        MousePosition();
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

    IEnumerator Pin_Summon()
    {
        float waitTime = 0.5f;

        if (GameSpawnManager.Inst.isPushCheck == false)
        {
            GameSpawnManager.Inst.isPushCheck = true;
            Instantiate(dartPin, point, Quaternion.identity).transform.parent = gameObject.transform;
            Time.timeScale = 0;

            Debug.Log("Lose");

            yield return new WaitForSecondsRealtime(waitTime);
            Destroy(transform.parent.gameObject);

            GameSpawnManager.Inst.Game_Summon();
        }
    }
}
