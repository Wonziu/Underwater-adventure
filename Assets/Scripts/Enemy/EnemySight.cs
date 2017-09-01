using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public ShootingEnemy Enemy;

    private void Start()
    {
        Enemy = transform.parent.GetComponent<ShootingEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            Enemy.Target = other.GetComponent<Player>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            Enemy.Target = null;
    }
}
