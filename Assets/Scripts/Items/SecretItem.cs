using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            gameObject.SetActive(false);
            coll.GetComponent<Player>().SecretItems.Add(this);
        }
    }
}