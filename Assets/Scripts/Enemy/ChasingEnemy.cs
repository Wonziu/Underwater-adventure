using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : Character
{
    private Vector2 startPosition;
    private Vector2 velocity;

    public int HealthPoints;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Target != null)
            velocity = Target.transform.position;
        else
            velocity = startPosition;

        MoveToPoint(velocity);
        Flip(velocity);
    }

    private void MoveToPoint(Vector2 v)
    {
        MyRigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, v,
            MovementSpeed * Time.deltaTime));
    }

    private void Flip(Vector2 v)
    {
        if (v.x - transform.position.x > 0 && FacingLeft || v.x - transform.position.x < 0 && !FacingLeft)
            ChangeDirection();
    }

    public override void KillCharacter()
    {
        if (HealthPoints > 0)
            HealthPoints--;
        else
            gameObject.SetActive(false);
    }
}
