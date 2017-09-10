using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingState : ITurtleBossState
{
    private TurtleBoss myBoss;
    private int chargeCount;

    public void Execute()
    {
        if (!myBoss.isCharging)
        {            
            myBoss.StartCoroutine(myBoss.ChargeAtPlayer());
        }
    }

    public void Enter(TurtleBoss enemy)
    {
        myBoss = enemy;
    }

    public void Exit()
    {
        
    }

    public void OnCollisionEnter(Collision2D coll)
    {
        
    }
}
