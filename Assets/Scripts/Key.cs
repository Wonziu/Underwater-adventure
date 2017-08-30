using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().Keys.Add(this);
            gameObject.SetActive(false);
        }
    }
}
