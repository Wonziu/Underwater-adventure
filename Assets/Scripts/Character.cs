using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float MovementSpeed;
    public bool FacingLeft = true;
    public Rigidbody2D MyRigidbody2D;

    public void Awake()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        FacingLeft = !FacingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
