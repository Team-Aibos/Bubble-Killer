using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void OnPickUp()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //����OnPickUp����
            OnPickUp();

            //�����������
            Destroy(gameObject);
        }
    }
}