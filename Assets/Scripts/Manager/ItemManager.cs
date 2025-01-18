using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : CompositeManager
{
    [Header("Item Prefabs")]
    [SerializeField] private GameObject[] herb;
    [SerializeField] private GameObject[] moveWithHurt;
    [SerializeField] private GameObject[] AllScreenBomb;
    [SerializeField] private GameObject[] MultiBullet;

    [Header("Spawn Settings")]
    [SerializeField] private float normalSpawnTime = 0.3f;    // �����������ݵ�ʱ�������룩
    [SerializeField] private SpriteRenderer background;    // ����ͼƬ

    public Vector2 sceneBoundMax;    //��ʾ�����߽�����ֵ
    public Vector2 sceneBoundMin;    //��ʾ�����߽����Сֵ

    void Start()
    {
        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;
    }

    void Update()
    {
       
    }
}
