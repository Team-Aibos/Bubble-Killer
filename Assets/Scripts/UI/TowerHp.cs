using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHp : MonoBehaviour
{
    [SerializeField] private Slider _towerHpSlider;   //������ʾ����Ѫ����Slider
    [SerializeField] private Image _HPShadow;         //������ʾѪӰ��Image 
    [SerializeField] private float currentHP;         //Ѫ����ǰѪ��

    private const float maxHealth = 100f;             //Ѫ�����Ѫ��
    private const float minHealth = 0f;               //Ѫ����СѪ��
    public Tower _tower;                              //��ȡ����

    private Color originalColor;                      // ����Ѫ��ԭʼ��ɫ
    [SerializeField] private float BloodShadowDuration = 0.2f;

    void Start()
    {
        //��ʼ��Ѫ��
        currentHP = _tower.GetHealth();
        //����Ѫ�����ֵ
        _towerHpSlider.maxValue = maxHealth;
        //����Ѫ����Сֵ
        _towerHpSlider.minValue = minHealth;
        //���ó�ʼѪ����ֵ
        _towerHpSlider.value = currentHP;
    }
    void Update()
    { 
        UpdateHP();
        UpdateShadow();
    }

    public void HPControlingTest()
    {
        //���ڲ���Ѫ��
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
        //��ȡ���ݵ�ǰѪ��
        //currentHP = _tower.GetHealth();
        //����Ѫ����ʾѪ��

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
