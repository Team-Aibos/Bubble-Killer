using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : CompositeManager
{
    #region Attributes
    [Header("Bubble Prefabs")]
    [SerializeField] private GameObject commonBubble;
    [SerializeField] private GameObject quickBubble;
    [SerializeField] private GameObject archerBubble;
    [SerializeField] private GameObject slimeBubble;

    [Header("Spawn Settings")]
    [SerializeField] private float normalSpawnTime = 0.3f;    // 正常生成泡泡的时间间隔（秒）
    [SerializeField] private float waveSpawnInterval;  // 波次生成的时间间隔（秒）
    [SerializeField] private int waveCount = 10;            // 每波生成的泡泡数量
    [SerializeField] private int mostBubbles = 120;         // 最多可以生成的泡泡数量
    private int bubbleCountNow = 0;           // 当前已经生成的泡泡数量
    [SerializeField] private SpriteRenderer background;    // 背景图片

    private float spawnTimer;        // 用来计时正常生成泡泡的计时器
    private float waveTimer;         // 用来计时波次生成的计时器
    private bool isWaveSpawning = false;  // 标记是否正在进行波次生成

    private Vector2 sceneBoundMax;    //表示场景边界的最大值
    private Vector2 sceneBoundMin;    //表示场景边界的最小值
    #endregion

    void Start()
    {
        sceneBoundMin = background.bounds.min;
        sceneBoundMax = background.bounds.max;

        spawnTimer = normalSpawnTime; // 初始化正常生成泡泡的时间间隔
        waveTimer = waveSpawnInterval; // 初始化波次生成的时间间隔
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;

        bubbleCountNow = CheckBubbleCount();

        // 如果正常生成的计时器到期，生成一个泡泡
        if (spawnTimer <= 0)
        {
            SpawnBubble(SpawnBubblePosition());
            spawnTimer = normalSpawnTime;  // 重置正常生成计时器
        }

        // 如果波次生成的计时器到期，并且当前没有在波次生成
        if (waveTimer <= 0 && !isWaveSpawning)
        {
            StartCoroutine(SpawnBubbleWave());
            waveTimer = waveSpawnInterval;  // 重置波次计时器
        }
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

        // 随机选择生成在场景的边界上
        if (Random.value < 0.5f) // 左右边界
        {
            x = Random.value < 0.5f ? sceneBoundMin.x : sceneBoundMax.x;
        }
        else // 上下边界
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
        // 查找所有标签为 "Bubble" 的对象
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        // 返回泡泡的数量
        return bubbles.Length;
    }

    // 生成一大波泡泡（波次生成）
    private IEnumerator SpawnBubbleWave()
    {
        isWaveSpawning = true;

        // 生成一大波泡泡
        for (int i = 0; i < waveCount; i++)
        {
            Vector2 position = SpawnBubblePosition();
            SpawnBubble(position);
            yield return new WaitForSeconds(0.1f); // 这里设置每个泡泡生成的间隔时间，控制泡泡的密集程度
        }

        waveCount += 3;    // 每次增加生成20个泡泡，增加难度

        isWaveSpawning = false;
        waveTimer = waveSpawnInterval; // 初始化波次生成的时间间隔
    }
}