using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    public float HorizontalCameraSize;
    public float VerticalCameraSize;
    public CameraController MyCameraController;
    private float d;

	void Start ()
	{
        SetCameraSize();
        
 

        //
        
    }
	
	void Update ()
    {
		
	}

    private void SetCameraSize()
    {
        

        if (VerticalCameraSize * Camera.main.aspect < HorizontalCameraSize)
        {
            d = HorizontalCameraSize / (2*Camera.main.aspect);
        }
        else d = VerticalCameraSize / 2;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            MyCameraController.SetCameraPosition(transform.position, d);
        }
    }
}
