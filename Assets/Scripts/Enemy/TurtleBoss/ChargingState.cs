﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingState : IBossState
{
    private FirstBoss myBoss;
    private int chargeCount;

    public void Execute()
    {
        if (!myBoss.IsCharging)
        {
            if (chargeCount == myBoss.MaxChargesCount)
            {
                myBoss.NextState = new ShootingState();
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
        myBoss.Flip(myBoss.MyRigidbody2D.velocity);
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
    }

    public void Exit()
    {

    }
}
