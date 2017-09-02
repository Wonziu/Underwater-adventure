using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Key Key;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            foreach (Key key in coll.collider.GetComponent<Player>().Keys)
                if (key == Key)
                {
                    gameObject.SetActive(false);
                    coll.collider.GetComponent<Player>().Keys.Remove(key);
                }
        }
    }
}
