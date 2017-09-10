using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    private int levelIndex;
    public List<Level> Levels;

    public GameObject LevelsParent;
    public Image LevelMenu;

    public Text LevelName;
    public Text LevelMaxCoins;
    public Text LevelMaxSecretItems;
    public Text LevelPlayerCoins;
    public Text LevelPlayerItems;

    private void Start()
    {
        CheckSaveFile();
        LoadSave();
    }

    public void OpenLevelMenu(int level)
    {
        LevelMenu.gameObject.SetActive(true);
        levelIndex = level;
        SetLevelMenuValues(level);
    }

    public void CloseLevelMenu()
    {
        LevelMenu.gameObject.SetActive(false);
    }

    private void SetLevelMenuValues(int level)
    {
        level = level - 1;

        LevelName.text = Levels[level].LevelName;
        LevelMaxCoins.text = Levels[level].Coins.ToString();
        LevelMaxSecretItems.text = Levels[level].SecretItems.ToString();

        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");

        LevelPlayerCoins.text = save.Levels[level].Coins.ToString();
        LevelPlayerItems.text = save.Levels[level].SecretItems.ToString();
    }

    public void LoadSave()
    {
        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");

        foreach (Transform transform1 in LevelsParent.transform)
        {
            transform1.GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < save.Levels.Count; i++)
        {
            LevelsParent.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void CheckSaveFile()
    {
        FileManagment.FileChecking();

        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");

        if (save == null)
        {
            SaveData newSave = new SaveData
            {
                Levels = new List<Level>()
            };

            newSave.Levels.Add(new Level()); 

            FileManagment.WriteFile("save.dat", newSave);
        }
    }
}