using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [SerializeField] private Image _PlayerHPBar;             // Player������
    [SerializeField] private Image _PlayerHPShadow;          // Player��������Ӱ
    [SerializeField] private Image _TowerHPBar;              // Tower������
    [SerializeField] private Image _TowerHPShadow;           // Tower��������Ӱ
    [SerializeField] private float maxHealth = 100f;         // �������ֵ
    private float currentHP;                                 // ��������ǰ����ֵ

    [SerializeField] private Player _player;          // ���
    [SerializeField] private Tower _tower;            // �˺�ֵ
  
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

    // �������HP
    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHP = maxHealth;
        _PlayerHPBar.fillAmount = currentHP / maxHealth;
        _PlayerHPShadow.fillAmount = currentHP / maxHealth;
        _TowerHPBar.fillAmount = currentHP / maxHealth;
        _TowerHPShadow.fillAmount = currentHP / maxHealth;
    }
    

    //���µ�ǰHP
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
