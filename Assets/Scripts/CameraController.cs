using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    private bool isPositionSet;
    private Vector2 myPlayerPosition;
    private Camera myCamera;

    public Player MyPlayer;
    public bool IsMoving = false;
    public float BottomBorder;
    public float UpperBorder;

    private void Start()
    {
        myCamera = Camera.main;
    }

	private void Update ()
    {   
        if (!isPositionSet)
            KeepCameraOnPlayer();   
    }

    private void KeepCameraOnPlayer()
    {
        myPlayerPosition = MyPlayer.transform.position;

        if (myPlayerPosition.y < BottomBorder)
            myCamera.transform.localPosition = new Vector2(myPlayerPosition.x, BottomBorder);
        else if (myPlayerPosition.y > UpperBorder)
            myCamera.transform.localPosition = new Vector2(myPlayerPosition.x, UpperBorder);
        else myCamera.transform.localPosition = new Vector2(myPlayerPosition.x, myPlayerPosition.y);
    }

    public void SetCameraPosition(Vector2 pos, float size, UnityAction afterCameraZoom = null)
    {
        isPositionSet = true;
        StartCoroutine(CameraPositionLerp(pos, size, afterCameraZoom));
    }

    private IEnumerator CameraPositionLerp(Vector2 endPos, float endSize, UnityAction afterCameraZoom = null)
    {
        IsMoving = true;

        Vector2 startPos = myCamera.transform.localPosition;
        float startSize = myCamera.orthographicSize;

        float progress = 0.0f;
        while (progress < 1.0f)
        {
            myCamera.transform.localPosition = Vector2.Lerp(startPos, endPos, progress);
            myCamera.orthographicSize = Mathf.Lerp(startSize, endSize, progress);
            progress += Time.deltaTime / 2;

            yield return new WaitForEndOfFrame();
        }

        IsMoving = false;

        if (afterCameraZoom != null)
            afterCameraZoom.Invoke();
    }
}
