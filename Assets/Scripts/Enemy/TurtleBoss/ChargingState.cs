using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingState : IBossState
{
    private FirstBoss myBoss;
    private int chargeCount;

    public void Execute()
    {
        if (!myBoss.isCharging)
        {
            if (chargeCount == myBoss.MaxChargesCount)
            {
                myBoss.nextState = new ShootingState();
                myBoss.ChangeState(new MovingState());
            }
            else
            {
                chargeCount++;
                myBoss.StartCoroutine(myBoss.ChargeAtPlayer());
            }
        }
    }

    public void ExecuteInFixed()
    {
        myBoss.MyRigidbody2D.velocity = myBoss.ChargeDirection;
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
    }

    public void Exit()
    {

    }
}
