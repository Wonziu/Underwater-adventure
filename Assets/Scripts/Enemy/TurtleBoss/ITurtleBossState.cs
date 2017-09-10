using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurtleBossState
{
    void Execute();
    void Enter(TurtleBoss enemy);
    void Exit();
    void OnCollisionEnter(Collision2D coll);
}