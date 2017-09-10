using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IBossState
{
    private FirstBoss myBoss;

    public void Execute()
    {
        myBoss.MyWeapon.Aim(myBoss.MyPlayer.transform.position);
        myBoss.MyWeapon.Shoot();
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
