using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : Item
{
    [SerializeField] private float healAmount;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    override public void OnPickUp()
    {
        player.Heal(healAmount);
    }
}
