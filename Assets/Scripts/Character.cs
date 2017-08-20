using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float MovementSpeed;
    public bool FacingLeft = true;
    public Animator MyAnimator;
    public Rigidbody2D myRigidbody2D;

    public void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        FacingLeft = !FacingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
