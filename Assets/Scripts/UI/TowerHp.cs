using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHp : MonoBehaviour
{
    [SerializeField] private Slider _towerHpSlider;   //用于显示堡垒血条的Slider
    [SerializeField] private Image _HPShadow;         //用于显示血影的Image 
    [SerializeField] private float currentHP;         //血条当前血量

    private const float maxHealth = 100f;             //血条最大血量
    private const float minHealth = 0f;               //血条最小血量
    public Tower _tower;                              //获取堡垒

    private Color originalColor;                      // 保存血条原始颜色
    [SerializeField] private float BloodShadowDuration = 0.2f;

    void Start()
    {
        //初始化血量
        currentHP = _tower.GetHealth();
        //设置血条最大值
        _towerHpSlider.maxValue = maxHealth;
        //设置血条最小值
        _towerHpSlider.minValue = minHealth;
        //设置初始血条的值
        _towerHpSlider.value = currentHP;
    }
    void Update()
    { 
        UpdateHP();
        UpdateShadow();
    }

    public void HPControlingTest()
    {
        //用于测试血条
        if(Input.GetKeyDown(KeyCode.J))
        {
            currentHP -= 10f;
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            currentHP += 10f;
        }
    }

    public void UpdateHP()
    {
        HPControlingTest();
        //获取堡垒当前血量
        //currentHP = _tower.GetHealth();
        //更新血条显示血量

        _towerHpSlider.value = currentHP;
    }
    public void UpdateShadow()
    {
       if (_HPShadow.fillAmount > currentHP / maxHealth)
       {
            _HPShadow.fillAmount -= 0.001f;
       }
        else
        {
            _HPShadow.fillAmount = currentHP / maxHealth;
        }
    }
}
