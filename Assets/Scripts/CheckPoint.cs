using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().CheckPoint = transform.position;
            coll.GetComponent<Player>().Ammo += 2;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
