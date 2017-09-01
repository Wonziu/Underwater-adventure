using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : Character
{
    public Weapon MyWeapon;
    public Vector2 CheckPoint;
    public List<Key> Keys;
    public int CoinsAmount;
    public int Ammo;

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
    }
	
	// Update is called once per frame
	private void Update ()
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
        // transform.Translate(new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed) * Time.deltaTime);
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            MyWeapon.Shoot();
            Ammo--;
        }
    }

    private void Flip()
    {
        if (horizontal > 0 && !FacingLeft || horizontal < 0 && FacingLeft)
        {
            ChangeDirection();
        }
    }

    public void KillPlayer()
    {
        transform.position = CheckPoint;
    }
}
