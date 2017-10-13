using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEggsState : IBossState
{
    private FirstBoss myBoss;

    public void Execute()
    {
        if (!myBoss.IsSpawning)
        {
            myBoss.ChangeState(new ChargingState());
        }
    }

    public void ExecuteInFixed()
    {
        
    }

    public void Enter(FirstBoss enemy)
    {
        myBoss = enemy;
        myBoss.StartCoroutine(myBoss.SpawnEggs());
    }

    public void Exit()
    {
        
    }
}
