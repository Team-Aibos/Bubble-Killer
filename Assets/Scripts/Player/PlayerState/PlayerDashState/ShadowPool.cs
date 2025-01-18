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

        //��ʼ�������
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);

            //���ض����
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
