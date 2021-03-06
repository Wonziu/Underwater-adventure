﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private float horizontal;
    private float vertical;
    private float baseSpeed;
    private float bonusSpeed;
    private bool isBoosting;
    private bool isPaused;

    public bool IsFatigued;
    public PlayerStats MyPlayerStats;
    public GameManager MyGameManager;
    public CameraController MyCameraController;
    public Weapon MyWeapon;
    public Vector2 CheckPoint;
    public List<Key> Keys;
    public int SecretItemsAmount;
    public int AmmoAmount;
    public int CoinsAmount;
    public float MaxBoostAmount;
    public float BoostAmount;

    private void Start()
    {
        CheckPoint = transform.position;
        MyGameManager.SetAmmoAmount(AmmoAmount);
        LoadUpgrades();
        BoostAmount = MaxBoostAmount;
    }

    private void LoadUpgrades()
    {
        SaveData save = FileManagment.ReadFile<SaveData>("save.dat");

        bonusSpeed = MyPlayerStats.BonusSpeed + save.BonusSpeed;
        baseSpeed = MyPlayerStats.MovementSpeed + save.MovementSpeed;
        MaxBoostAmount = MyPlayerStats.MaxBoostAmount + save.MaxBoostAmount;
    }

    private void Update()
    {
        MyWeapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        HandleInput();
    }

    private void FixedUpdate()
    {
        if (!MyCameraController.IsMoving)
        {
            Flip();
            MyRigidbody2D.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed);
        }
        else
            MyRigidbody2D.velocity = Vector2.zero;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MyGameManager.ToggleOptions();
            isPaused = !isPaused;
        }

        if (isPaused)
            return;

        if (Input.GetKey(KeyCode.Mouse0) && AmmoAmount > 0)
        {
            if (MyWeapon.Shoot())
            {
                AmmoAmount--;
                MyGameManager.SetAmmoAmount(AmmoAmount);
            }
        }

        if (Input.GetKey(KeyCode.Mouse1) && !IsFatigued && BoostAmount > 0)
            UseBoost();
        else
            LoadBoost();
    }

    private void UseBoost()
    {
        isBoosting = true;
        BoostAmount -= 1;
        MovementSpeed = baseSpeed + bonusSpeed;
    }

    private void LoadBoost()
    {
        BoostAmount = Mathf.Clamp(BoostAmount, 0, MaxBoostAmount);

        if (Math.Abs(BoostAmount) < 0.25f)
            IsFatigued = true;
        else if (Math.Abs(BoostAmount) > MaxBoostAmount / 5)
            IsFatigued = false;

        isBoosting = false;
        BoostAmount += 0.1f;
        MovementSpeed = baseSpeed;
    }

    private void Flip()
    {
        if (horizontal > 0 && !FacingLeft || horizontal < 0 && FacingLeft)
            ChangeDirection();
    }

    public override void TakeDamage()
    {
        if (!MyGameManager.BossFight)
        {
            MyGameManager.DestroyProjectiles();
            MyGameManager.StartCoroutine(MyGameManager.DeathAnimation(this, ResetPlayer));
            gameObject.SetActive(false);
        }
        else
            ReloadLevel();
    }

    private void ReloadLevel()
    {
        gameObject.SetActive(false);
        MyGameManager.StartCoroutine(MyGameManager.DeathAnimation(this,
            () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single)));
    }

    private void ResetPlayer()
    {
        gameObject.SetActive(true);
        RemoveKeys();
        transform.position = CheckPoint;
    }

    private void RemoveKeys()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            Key key = Keys[i];
            if (key.PlayerCheckpoint == CheckPoint)
            {
                key.ResetKey();
                Keys.Remove(key);
            }
        }
    }

    public void PickUpCoin()
    {
        CoinsAmount++;
        MyGameManager.SetCoinsAmount(CoinsAmount);
    }

    public void SetCheckPoint(Vector2 pos)
    {
        CheckPoint = pos;
        AmmoAmount += 1;
        MyGameManager.SetAmmoAmount(AmmoAmount);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy" || coll.tag == "Boss")
            TakeDamage();
        else if (coll.tag == "Coin")
        {
            coll.gameObject.SetActive(false);
            PickUpCoin();
        }
        else if (coll.tag == "SecretItem")
        {
            coll.gameObject.SetActive(false);
            SecretItemsAmount++;
        }
    }
}