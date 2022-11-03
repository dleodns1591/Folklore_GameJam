using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hammer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Piece"))
        {
            collision.transform.DOLocalMoveX(-540, 0.8f);

            yield return new WaitForSeconds(1);

            Destroy(collision.gameObject);
        }
    }
}
