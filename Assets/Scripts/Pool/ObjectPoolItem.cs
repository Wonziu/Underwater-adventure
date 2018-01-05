using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolItem
{
    public int PoolAmount;
    public string Key;
    public Projectile ItemToPool;
}
