using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMultiple : Item
{
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public override void OnPickUp()
    {
        player.GetComponent<Weapon>().UpgradeWeapon();
    }
}