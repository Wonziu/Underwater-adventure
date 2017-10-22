using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : IBossState
{
    private FirstBoss myBoss;
    
    public void Execute()
    {
        if (myBoss.transform.position == myBoss.NextPosition)
        {
            myBoss.ChangeState(myBoss.NextState);
        }
    }

    public void ExecuteInFixed()
    {
        myBoss.MyRigidbody2D.MovePosition(Vector2.MoveTowards(myBoss.transform.position, myBoss.NextPosition,
            myBoss.MovementSpeed * Time.deltaTime));
        myBoss.Flip(myBoss.NextPosition - myBoss.transform.position);
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
        myBoss.GetNextPosition();
    }

    public void Exit()
    {
        myBoss.NextState = null;
    }
}
