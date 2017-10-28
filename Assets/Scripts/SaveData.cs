using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int Coins;
    public List<Level> Levels;

    public int BonusSpeed;
    public float MaxBoostAmount;
    public int MovementSpeed;
}