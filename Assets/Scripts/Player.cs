using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(moveHorizontal, moveVertical) / 20);

	    Camera.main.transform.position = new Vector3(transform.position.x, 0, -5);
	}
}
