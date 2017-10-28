using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text CoinsAmount;

    public void UpgradeMovementSpeed(int cost)
    {     
        if (CanBuy(cost))
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.MovementSpeed += 1;

            SaveUpgrade(save, cost);
        }
    }

    public void UpgradeBoostAmount(int cost)
    {
        if (CanBuy(cost))
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.MaxBoostAmount += 30;

            SaveUpgrade(save, cost);
        }
    }

    public void UpgradeBoostSpeed(int cost)
    {
        if (CanBuy(cost))
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.BonusSpeed += 1;

            SaveUpgrade(save, cost);
        }
    }

    private void SaveUpgrade(SaveData save, int cost)
    {
        save.Coins -= cost;
        CoinsAmount.text = save.Coins.ToString();

        FileManagment.WriteFile("save.dat", save);
    }

    private bool CanBuy(int cost)
    {
        if (int.Parse(CoinsAmount.text) >= cost)  
            return true;

        return false;
    }
}