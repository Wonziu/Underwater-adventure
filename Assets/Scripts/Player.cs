using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public Weapon MyWeapon;

    private bool facingRight = true;
    private Rigidbody2D myRigidbody2D;
    
	private void Awake ()
	{
	    myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        HandleInput(horizontal, vertical);
        Flip(horizontal);
	}

    private void HandleInput(float horizontal, float vertical)
    {
        myRigidbody2D.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed);

        if (Input.GetButton("Fire1"))
            MyWeapon.Shoot();
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
