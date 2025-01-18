using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Tower tower = collision.gameObject.GetComponent<Tower>();
            if (tower != null)
            {
                tower.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.PlayerGetHurt(damage);
                Destroy(gameObject);
            }
        }
    }
}
