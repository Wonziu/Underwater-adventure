using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int MaxCoinsAmount;

    public Text AmmoText;
    public Text CoinsText;
    public Text MaxCoinsText;

    void Start ()
    {
		SetMaxCoinsAmount();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetCoinsAmount(int coins)
    {
        CoinsText.text = coins.ToString();
    }

    private void SetMaxCoinsAmount()
    {
        MaxCoinsText.text = MaxCoinsAmount.ToString();
    }

    public void SetAmmoAmount(int ammo)
    {
        AmmoText.text = ammo.ToString();
    }
}
