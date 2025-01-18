using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    #region Attributes
    [Header("Bubble Prefabs")]
    [SerializeField] private GameObject commonBubble;
    [SerializeField] private GameObject quickBubble;
    [SerializeField] private GameObject archerBubble;
    [SerializeField] private GameObject slimeBubble;

    [Header("Spawn Settings")]
    [SerializeField] private float normalSpawnTime = 0.3f;    // �����������ݵ�ʱ�������룩
    [SerializeField] private float waveSpawnInterval;  // �������ɵ�ʱ�������룩
    [SerializeField] private int waveCount = 15;            // ÿ�����ɵ���������
    [SerializeField] private int mostBubbles = 120;         // ���������ɵ���������
    [SerializeField] private int bubbleCountNow = 0;           // ��ǰ�Ѿ����ɵ���������
    [SerializeField] private SpriteRenderer background;    // ����ͼƬ

    private float runTime;    //��ʾ����ʱ��
    private float spawnTimer;        // ������ʱ�����������ݵļ�ʱ��
    private float waveTimer;         // ������ʱ�������ɵļ�ʱ��
    private bool isWaveSpawning = false;  // ����Ƿ����ڽ��в�������

    public Vector2 sceneBoundMax;    //��ʾ�����߽�����ֵ
    public Vector2 sceneBoundMin;    //��ʾ�����߽����Сֵ
    #endregion

    void Start()
    {
        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;

        spawnTimer = normalSpawnTime; // ��ʼ�������������ݵ�ʱ����
        waveTimer = waveSpawnInterval; // ��ʼ���������ɵ�ʱ����
    }

    void Update()
    {
        runTime += Time.deltaTime;

        spawnTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;

        bubbleCountNow = CheckBubbleCount();

        // ����������ɵļ�ʱ�����ڣ�����һ������
        if (spawnTimer <= 0)
        {
            SpawnBubble(SpawnBubblePosition());
            spawnTimer = normalSpawnTime;  // �����������ɼ�ʱ��
        }

        // ����������ɵļ�ʱ�����ڣ����ҵ�ǰû���ڲ�������
        if (waveTimer <= 0 && !isWaveSpawning)
        {
            StartCoroutine(SpawnBubbleWave());
            waveTimer = waveSpawnInterval;  // ���ò��μ�ʱ��
        }
    }

    public float SetRandomNum(int x, int y)
    {
        float randomNum = Random.Range(x, y);
        return randomNum;
    }

    public GameObject SpawnBubbleType()
    {
        float randomNum = SetRandomNum(0, 100);
        if (randomNum >= 0 && randomNum <= 40)
        {
            return commonBubble;
        }
        else if (randomNum > 40 && randomNum <= 70)
        {
            return quickBubble;
        }
        else if (randomNum > 70 && randomNum <= 90)
        {
            return archerBubble;
        }
        else
        {
            return slimeBubble;
        }
    }

    public Vector2 SpawnBubblePosition()
    {
        float x = Random.Range(sceneBoundMin.x, sceneBoundMax.x);
        float y = Random.Range(sceneBoundMin.y, sceneBoundMax.y);

        // ���ѡ�������ڳ����ı߽���
        if (Random.value < 0.5f) // ���ұ߽�
        {
            x = Random.value < 0.5f ? sceneBoundMin.x : sceneBoundMax.x;
        }
        else // ���±߽�
        {
            y = Random.value < 0.5f ? sceneBoundMin.y : sceneBoundMax.y;
        }

        return new Vector2(x, y);
    }

    public void SpawnBubble(Vector2 position)
    {
        if (bubbleCountNow <= mostBubbles)
        {
            GameObject bubble = SpawnBubbleType();
            Instantiate(bubble, position, Quaternion.identity);
        }
    }

    public int CheckBubbleCount()
    {
        // �������б�ǩΪ "Bubble" �Ķ���
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        // �������ݵ�����
        return bubbles.Length;
    }

    // ����һ�����ݣ��������ɣ�
    private IEnumerator SpawnBubbleWave()
    {
        isWaveSpawning = true;

        // ����һ������
        for (int i = 0; i < waveCount; i++)
        {
            Vector2 position = SpawnBubblePosition();
            SpawnBubble(position);
            yield return new WaitForSeconds(0.1f); // ��������ÿ���������ɵļ��ʱ�䣬�������ݵ��ܼ��̶�
        }

        waveCount += 20;    // ÿ����������20�����ݣ������Ѷ�

        isWaveSpawning = false;
        waveTimer = waveSpawnInterval; // ��ʼ���������ɵ�ʱ����
    }
}