using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossState
{
    void Execute();
    void ExecuteInFixed();
    void Enter(FirstBoss enemy);
    void Exit();
}