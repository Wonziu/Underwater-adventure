using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    private float ortographicSize;

    public float HorizontalCameraSize;
    public float VerticalCameraSize;
    public CameraController MyCameraController;
    public FirstBoss Boss;

    void Start()
    {
        SetCameraSize();
    }

    void Update()
    {

    }

    private void SetCameraSize()
    {
        if (VerticalCameraSize * Camera.main.aspect < HorizontalCameraSize)
        {
            ortographicSize = HorizontalCameraSize / (2 * Camera.main.aspect);
        }
        else ortographicSize = VerticalCameraSize / 2;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            MyCameraController.SetCameraPosition(transform.position, ortographicSize, () => Boss.ActivateBoss());
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}