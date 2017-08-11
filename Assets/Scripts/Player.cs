using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float LowerBorder;

    private Rigidbody2D myRigidbody2D;
    

	void Start ()
	{
	    myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        myRigidbody2D.AddForce(new Vector2(moveHorizontal, moveVertical) * 5);

	    if (transform.position.y < LowerBorder)
	    {      
	        Camera.main.transform.position = new Vector3(transform.position.x, 5.5f, -10);
	    }

        myRigidbody2D.velocity = new Vector2(moveHorizontal * 4, moveVertical * 4);
	}
}
