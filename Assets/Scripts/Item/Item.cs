using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void OnPickUp()
    {

    }

   public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //����OnPickUp����
            OnPickUp();

            //�����������
            Destroy(gameObject);
        }
    }
}
