using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IBossState
{
    private FirstBoss myBoss;
    private int AmmoFired;

    public void Execute()
    {
        if (AmmoFired < 5)
        {
            AmmoFired++;
            myBoss.MyWeapon.Aim(myBoss.Target.transform.position);
            myBoss.MyWeapon.Shoot();
        }

        else
        {
            if (myBoss.NextShootingPosition == myBoss.ShootingPositions[0])
            {
                myBoss.ChangeState(new ChargingState());
            }
            else
            {
                myBoss.nextState = new ShootingState();
                myBoss.ChangeState(new MovingState());
            }        
        }        
    }

    public void ExecuteInFixed()
    {
        
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
    }

    public void Exit()
    {
        
    }
}
