using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player MyPlayer;
    
    public float BottomBorder;
    public float UpperBorder;

    private Vector2 myPlayerPosition;
    private Camera myCamera;

    private void Start()
    {
        myCamera = Camera.main;
    }

	// Update is called once per frame
	private void Update ()
    {
        myPlayerPosition = MyPlayer.transform.position;

        if (myPlayerPosition.y < BottomBorder)
            myCamera.transform.localPosition = new Vector2(myPlayerPosition.x, BottomBorder);
        else if (myPlayerPosition.y > UpperBorder)
            myCamera.transform.localPosition = new Vector2(myPlayerPosition.x, UpperBorder);
        else myCamera.transform.localPosition = new Vector2(myPlayerPosition.x , myPlayerPosition.y);       
    }
}
