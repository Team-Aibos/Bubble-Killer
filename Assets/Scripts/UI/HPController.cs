using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [SerializeField] private Image _PlayerHPBar;             // Player生命条
    [SerializeField] private Image _PlayerHPShadow;          // Player生命条阴影
    [SerializeField] private Image _TowerHPBar;              // Tower生命条
    [SerializeField] private Image _TowerHPShadow;           // Tower生命条阴影
    [SerializeField] private float maxHealth = 100f;         // 最大生命值
    private float currentHP;                                 // 生命条当前生命值

    [SerializeField] private Player _player;          // 玩家
    [SerializeField] private Tower _tower;            // 伤害值
  
    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    void Update()
    {
        SetCurrentHealth(_player.GetHP(), _PlayerHPBar);
        SetCurrentHealth(_tower.GetHealth(), _TowerHPBar);
        UpdateShadow(_PlayerHPBar, _PlayerHPShadow);
        UpdateShadow(_TowerHPBar, _TowerHPShadow);
    }

    // 设置最大HP
    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHP = maxHealth;
        _PlayerHPBar.fillAmount = currentHP / maxHealth;
        _PlayerHPShadow.fillAmount = currentHP / maxHealth;
        _TowerHPBar.fillAmount = currentHP / maxHealth;
        _TowerHPShadow.fillAmount = currentHP / maxHealth;
    }
    

    //更新当前HP
    public void SetCurrentHealth(float health, Image _HPBar)
    {
        if(health>=0 && health<=maxHealth)
        { 
            currentHP = health;
        }
        _HPBar.fillAmount = currentHP / maxHealth;
    }


    public void UpdateShadow(Image _HPBar, Image _HPShadow)
    {
       if (_HPShadow.fillAmount > _HPBar.fillAmount)
       {
            _HPShadow.fillAmount -= 0.0007f;
       }
        else
        {
            _HPShadow.fillAmount = _HPBar.fillAmount;
        }
    }
}
