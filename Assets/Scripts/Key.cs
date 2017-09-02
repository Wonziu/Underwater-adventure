using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Vector2 keyPosition;
    public Vector2 PlayerCheckpoint;

    private void Start()
    {
        keyPosition = transform.position;
    }

    public void ResetKey()
    {
        transform.position = keyPosition;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().Keys.Add(this);
            PlayerCheckpoint = coll.GetComponent<Player>().CheckPoint;
            gameObject.SetActive(false);
        }
    }
}
