using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int MaxCoinsAmount;
    private int MaxSecretItemsAmount;

    public GameObject UIObject;
    public Transform CoinsParent;
    public Transform SecretItemsParent;

    public GUITexture Overlay;
    public Text AmmoText;
    public Text CoinsText;
    public Text MaxCoinsText;

    void Start()
    {
        SetMaxCoinsAmount();
        SetMaxSecretItems();
        StartCoroutine(FadeInAnimation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCoinsAmount(int coins)
    {
        CoinsText.text = coins.ToString();
    }

    private void SetMaxSecretItems()
    {
        MaxSecretItemsAmount = SecretItemsParent.childCount;
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
            StartCoroutine(FadeOutAnimation());
    }

    public IEnumerator FadeOutAnimation()
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
    }

    public IEnumerator FadeInAnimation()
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