using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IBossState
{
    private FirstBoss myBoss;
    private int AmmoFired;

    public void Execute()
    {
        if (AmmoFired < myBoss.BulletsAmount)
        {
            myBoss.MyWeapon.Aim(myBoss.Target.transform.position);

            if (myBoss.MyWeapon.Shoot())
                AmmoFired++;
        }

        else
        {
            if (myBoss.NextPosition == myBoss.ShootingPositions[0])
            {
                int i = Random.Range(0, 2);

                if (i == 0)
                {
                    myBoss.ChangeState(new ChargingState());
                }
                else myBoss.ChangeState(new SpawningEggsState());
            }
            else
            {
                myBoss.NextState = new ShootingState();
                myBoss.ChangeState(new MovingState());
            }
        }
    }

    public void ExecuteInFixed()
    {
        myBoss.Flip(myBoss.Target.transform.position - myBoss.transform.position);
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
    }

    public void Exit()
    {

    }
}
