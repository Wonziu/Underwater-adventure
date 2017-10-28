using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Character Enemy;

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
