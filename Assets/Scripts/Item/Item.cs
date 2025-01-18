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
            //调用OnPickUp方法
            OnPickUp();

            //销毁物体对象
            Destroy(gameObject);
        }
    }
}
