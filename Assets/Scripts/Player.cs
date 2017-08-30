using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : Character
{
    public Weapon MyWeapon;
    public List<Key> Keys;

    private Rigidbody2D myRigidbody2D;
    private float horizontal;
    private float vertical;

    private void Awake ()
	{
	    myRigidbody2D = GetComponent<Rigidbody2D>();
        base.Awake();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        MyWeapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        HandleInput();
        Flip();
        myRigidbody2D.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed);
    }

    private void FixedUpdate()
    {
        // transform.Translate(new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed) * Time.deltaTime);
    }

    private void HandleInput()
    { 
        if (Input.GetButton("Fire1"))
            MyWeapon.Shoot();
    }

    private void Flip()
    {
        if (horizontal > 0 && !FacingLeft || horizontal < 0 && FacingLeft)
        {
            ChangeDirection();
        }
    }
}
