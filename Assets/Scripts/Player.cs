using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : Character
{
    public GameManager MyGameManager;
    public Weapon MyWeapon;
    public Vector2 CheckPoint;
    public List<Key> Keys;
    public List<SecretItem> SecretItems;
    public int AmmoAmount;
    public int CoinsAmount;

    private Rigidbody2D myRigidbody2D;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        base.Awake();
    }

    private void Start()
    {
        CheckPoint = transform.position;
        MyGameManager.SetAmmoAmount(AmmoAmount);
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        MyWeapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        HandleInput();
        Flip();
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && AmmoAmount > 0)
        {
            MyWeapon.Shoot();
            AmmoAmount--;
            MyGameManager.SetAmmoAmount(AmmoAmount);
        }
    }

    private void Flip()
    {
        if (horizontal > 0 && !FacingLeft || horizontal < 0 && FacingLeft)
            ChangeDirection();
    }

    public void KillPlayer()
    {
        MyGameManager.StartCoroutine(MyGameManager.DeathAnimation(this, ResetPlayer));
        gameObject.SetActive(false);
    }

    public void ResetPlayer()
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
}