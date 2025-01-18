using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithHurt : Item
{
    [SerializeField] private float damage;
    [SerializeField] private float duration;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public override void OnPickUp()
    {
        player.EnableMoveWithHurt(damage, duration);
    }
}
