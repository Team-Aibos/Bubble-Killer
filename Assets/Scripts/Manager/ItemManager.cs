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
    [SerializeField] private GameObject allScreenBomb;
    [SerializeField] private GameObject multiBullet;
    [SerializeField] private GameObject towerMultiply;

    [Header("Spawn Settings")]
    [SerializeField] private float normalSpawnTime;    // �����������ݵ�ʱ�������룩
    [SerializeField] private float edgeMargin;    // �߽��������ݵı߾ࣨ�ף�
    [SerializeField] float edgeProbability;
    [SerializeField] private SpriteRenderer background;    // ����ͼƬ

    private float spawnTimer;    // ��ǰ���ɵ��߼�ʱ��

    private Vector2 sceneBoundMax;    //��ʾ�����߽�����ֵ
    private Vector2 sceneBoundMin;    //��ʾ�����߽����Сֵ
    #endregion

    void Start()
    {
        spawnTimer = normalSpawnTime;     // ��ʼ�����ɼ�ʱ��

        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0) 
        {
            SpawnBubble(SpawnItemPosition());
            spawnTimer = normalSpawnTime;  // �����������ɼ�ʱ��
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
        if (randomNum >= 0 && randomNum <= 30)
        {
            return herb;
        }
        else if (randomNum > 30 && randomNum <= 60)
        {
            return moveWithHurt;
        }
        else if (randomNum > 70 && randomNum <= 90)
        {
            return towerMultiply;
        }
        else
        {
            return allScreenBomb;
        }
    }

    public Vector2 SpawnItemPosition()
    {
        float x, y;

        // ����߽�Ŀ����ɷ�Χ
        float edgeMinX = sceneBoundMin.x + edgeMargin;
        float edgeMaxX = sceneBoundMax.x - edgeMargin;
        float edgeMinY = sceneBoundMin.y + edgeMargin;
        float edgeMaxY = sceneBoundMax.y - edgeMargin;

        // ���ݸ��ʾ����Ƿ������ڱ߽�����
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
            // ���м���������
            x = Random.Range(edgeMinX + edgeMargin, edgeMaxX - edgeMargin);
            y = Random.Range(edgeMinX + edgeMargin, edgeMaxX - edgeMargin);
        }

        return new Vector2(x, y);
    }
}
