using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : CompositeManager
{
    #region Attributes
    [Header("Item Prefabs")]
    [SerializeField] private GameObject herb;
    [SerializeField] private GameObject moveWithHurt;
    [SerializeField] private GameObject AllScreenBomb;
    [SerializeField] private GameObject MultiBullet;

    [Header("Spawn Settings")]
    [SerializeField] private float normalSpawnTime;    // 正常生成泡泡的时间间隔（秒）
    [SerializeField] private float edgeMargin;    // 边界生成泡泡的边距（米）
    [SerializeField] float edgeProbability;
    [SerializeField] private SpriteRenderer background;    // 背景图片

    private float spawnTimer;    // 当前生成道具计时器

    private Vector2 sceneBoundMax;    //表示场景边界的最大值
    private Vector2 sceneBoundMin;    //表示场景边界的最小值
    #endregion

    void Start()
    {
        spawnTimer = normalSpawnTime;     // 初始化生成计时器

        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0) 
        {
            SpawnBubble(SpawnItemPosition());
            spawnTimer = normalSpawnTime;  // 重置正常生成计时器
        }
    }

    public void SpawnBubble(Vector2 position)
    {
        GameObject item = SpawnItemType();
        Instantiate(item, position, Quaternion.identity);
    }

    public GameObject SpawnItemType()
    {
        float randomNum = SetRandomNum(0, 100);
        if (randomNum >= 0 && randomNum <= 40)
        {
            return herb;
        }
        else if (randomNum > 40 && randomNum <= 70)
        {
            return moveWithHurt;
        }
        else if (randomNum > 70 && randomNum <= 90)
        {
            return AllScreenBomb;
        }
        else
        {
            return MultiBullet;
        }
    }

    public Vector2 SpawnItemPosition()
    {
        float x, y;

        // 计算边界的可生成范围
        float edgeMinX = sceneBoundMin.x + edgeMargin;
        float edgeMaxX = sceneBoundMax.x - edgeMargin;
        float edgeMinY = sceneBoundMin.y + edgeMargin;
        float edgeMaxY = sceneBoundMax.y - edgeMargin;

        // 根据概率决定是否生成在边界区域
        if (Random.value < edgeProbability)
        {
            while (true)
            {
                float tempX = Random.Range(edgeMinX + edgeMargin, edgeMaxX - edgeMargin);
                float tempY = Random.Range(edgeMinY + edgeMargin, edgeMaxY - edgeMargin);
                if ((tempX < edgeMaxX - 2 * edgeMargin && tempX > edgeMinX + 2 * edgeMargin) || tempY < edgeMaxY - 2 * edgeMargin && tempY > edgeMinY + 2 * edgeMargin)
                    continue;
                else
                {
                    x = tempX;
                    y = tempY;
                    break;
                }
            }
           
        }
        else
        {
            // 在中间区域生成
            x = Random.Range(edgeMinX + edgeMargin, edgeMaxX - edgeMargin);
            y = Random.Range(edgeMinX + edgeMargin, edgeMaxX - edgeMargin);
        }

        return new Vector2(x, y);
    }
}
