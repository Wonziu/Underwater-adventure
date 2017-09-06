﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int MaxCoinsAmount;

    public GameObject UIObject;
    public GUITexture Overlay;
    public Player MyPlayer;
    public Transform CoinsParent;
    public Transform SecretItemsParent;

    
    public Text AmmoText;
    public Text CoinsText;
    public Text MaxCoinsText;

    void Start()
    {
        SetMaxCoinsAmount();
        StartCoroutine(FadeOutAnimation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCoinsAmount(int coins)
    {
        CoinsText.text = coins.ToString();
    }

    private void SetMaxCoinsAmount()
    {
        MaxCoinsAmount = CoinsParent.childCount;

        MaxCoinsText.text = MaxCoinsAmount.ToString();
    }

    public void SetAmmoAmount(int ammo)
    {
        AmmoText.text = ammo.ToString();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            SaveResults();
            StartCoroutine(FadeInAnimation(() => SceneManager.LoadScene("LevelSelectionScene")));
        }
    }

    private void SaveResults()
    {
        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");

        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == save.Levels.Count- 1) 
            save.Levels.Add(new Level());

        if (save.Levels[index].Coins < MyPlayer.CoinsAmount)
            save.Levels[SceneManager.GetActiveScene().buildIndex].Coins = MyPlayer.CoinsAmount;
        if (save.Levels[index].SecretItems < MyPlayer.CoinsAmount)
            save.Levels[SceneManager.GetActiveScene().buildIndex].SecretItems = MyPlayer.SecretItemsAmount;

        FileManagment.WriteFile("save.dat", save);
    }

    public IEnumerator FadeInAnimation(UnityAction afterFadeOut = null)
    {
        UIObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        Overlay.color = Color.clear;
        float progress = 0.0f;
        while (progress < 1.0f)
        {
            Overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += Time.deltaTime;
            yield return null;
        }
        Overlay.color = Color.black;

        if (afterFadeOut != null)
            afterFadeOut.Invoke();
    }

    public IEnumerator FadeOutAnimation()
    {
        Overlay.color = Color.black;
        float progress = 0.0f;
        while (progress < 1.0f)
        {
            Overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += Time.deltaTime;
            yield return null;
        }
        Overlay.color = Color.clear;

        yield return new WaitForSeconds(0.3f);
        UIObject.SetActive(true);
    }

    public IEnumerator DeathAnimation(Player myPlayer, UnityAction afterFadeIn = null, UnityAction afterFadeOut = null)
    {
        Overlay.color = Color.clear;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += Time.deltaTime * 3;
            yield return null;
        }
        Overlay.color = Color.black;

        if (afterFadeIn != null)
            afterFadeIn.Invoke();

        progress = 0.0f;

        while (progress < 1.0f)
        {
            Overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += Time.deltaTime * 3;
            yield return null;
        }
        Overlay.color = Color.clear;

        if (afterFadeOut != null)
            afterFadeOut.Invoke();
    }
}