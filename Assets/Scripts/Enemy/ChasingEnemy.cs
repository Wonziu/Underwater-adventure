using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : Character
{
    private Vector2 startPosition;

    public int HealthPoints;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Target != null)
            ChaseTarget();
        else 
            ReturnToStart();
    }

    private void ChaseTarget()
    {
        MyRigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, Target.transform.position,
            MovementSpeed * Time.deltaTime));
    }

    private void ReturnToStart()
    {
        MyRigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, startPosition,
            MovementSpeed * Time.deltaTime));
    }

    public override void KillCharacter()
    {
        if (HealthPoints > 0)
            HealthPoints--;
        else
            gameObject.SetActive(false);
    }
}
