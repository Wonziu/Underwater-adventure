using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().SetCheckPoint(transform.position);
            GetComponent<Animator>().SetBool("IsSet", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
