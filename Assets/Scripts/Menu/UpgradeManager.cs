using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text CoinsAmount;
    public Text FirstUpgradeLevel;
    public Text SecondUpgradeLevel;
    public Text ThirdUpgradeLevel;

    public float BonusMovementSpeed;
    public float BonusMaxBoostAmount;
    public float BonusSpeed;

    public Button FirstUpgrade;
    public Button SecondUpgrade;
    public Button ThirdUpgrade;


    private void Start()
    {
        SetUpgradesLevels();
    }

    private void SetUpgradesLevels()
    {
        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
        
        SetFirstUpgradeLevel(save);
        SetSecondUpgradeLevel(save);
        SetThirdUpgradeLevel(save);
    }

    private void SetFirstUpgradeLevel(SaveData save)
    {
        float level = save.MovementSpeed / BonusMovementSpeed;
        FirstUpgradeLevel.text = "Level: " + level.ToString(CultureInfo.CurrentCulture);

        if (level >= 3)
            FirstUpgrade.interactable = false;
    }

    private void SetSecondUpgradeLevel(SaveData save)
    {
        float level = save.MaxBoostAmount / BonusMaxBoostAmount;
        SecondUpgradeLevel.text = "Level: " + level.ToString(CultureInfo.CurrentCulture);

        if (level >= 3)
            SecondUpgrade.interactable = false;
    }

    private void SetThirdUpgradeLevel(SaveData save)
    {
        float level = save.BonusSpeed / BonusSpeed;
        ThirdUpgradeLevel.text = "Level: " + level.ToString(CultureInfo.CurrentCulture);

        if (level >= 3)
            ThirdUpgrade.interactable = false;
    }

    public void UpgradeMovementSpeed(int cost)
    {     
        if (CanBuy(cost))
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.MovementSpeed += BonusMovementSpeed;
                
            SaveUpgrade(save, cost);
            SetFirstUpgradeLevel(save);
        }
    }

    public void UpgradeBoostAmount(int cost)
    {
        if (CanBuy(cost))
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.MaxBoostAmount += BonusMaxBoostAmount;

            SaveUpgrade(save, cost);
            SetSecondUpgradeLevel(save);
        }
    }

    public void UpgradeBoostSpeed(int cost)
    {
        if (CanBuy(cost))       
        {
            SaveData save = FileManagment.ReadFile<SaveData>("save.dat");
            save.BonusSpeed += BonusSpeed;

            SaveUpgrade(save, cost);
            SetThirdUpgradeLevel(save);
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