using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int Coins;
    public List<Level> Levels;

    public float BonusSpeed;
    public float MaxBoostAmount;
    public float MovementSpeed;
}