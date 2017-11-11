using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private readonly string[] panelNames = { "Upgrades", "Levels"};
    private readonly string[] panelTitles = { "Choose Your Level", "Upgrade Your Ship"};

    private int panelNameIndex = 0;

    public Text Title;
    public Text PanelName;

    public List<GameObject> PanelObjects;

    public void ChangeMainPanel()
    {
        DisablePanels();

        int index = ++panelNameIndex % panelNames.Length;

        PanelObjects[index].SetActive(true);
        Title.text = panelTitles[index];
        PanelName.text = panelNames[index];
    }

    private void DisablePanels()
    {
        foreach (var panelObject in PanelObjects)
        {
            panelObject.SetActive(false);
        }
    }
}
