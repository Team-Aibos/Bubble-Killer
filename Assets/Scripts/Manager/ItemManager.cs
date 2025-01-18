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
    [SerializeField] private float normalSpawnTime = 0.3f;    // 正常生成泡泡的时间间隔（秒）
    [SerializeField] private SpriteRenderer background;    // 背景图片

    public Vector2 sceneBoundMax;    //表示场景边界的最大值
    public Vector2 sceneBoundMin;    //表示场景边界的最小值

    void Start()
    {
        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;
    }

    void Update()
    {
       
    }
}
