using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float MovementSpeed;
    public bool FacingLeft = true;
    public Animator MyAnimator;

    public void Awake()
    {
        MyAnimator = GetComponent<Animator>();
    }

    public void ChangeDirection()
    {
        FacingLeft = !FacingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
