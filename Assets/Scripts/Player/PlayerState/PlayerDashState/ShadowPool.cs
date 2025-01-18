using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;

    public GameObject shadowPrefab;

    public int shadowCount;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;

        //初始化对象池
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);

            //返回对象池
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        pool.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if(pool.Count == 0)
        {
            FillPool();
        }
        var outShadow = pool.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }
}
