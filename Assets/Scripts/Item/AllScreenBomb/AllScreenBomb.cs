using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScreenBomb: Item
{
    [SerializeField] private float damage;

    override public void OnPickUp()
    {
        Bubble[] bubbles = GameObject.FindObjectsOfType<Bubble>();
        foreach (Bubble bubble in bubbles)
        {
            bubble.TakeDamage(damage);
        }
    }
}
