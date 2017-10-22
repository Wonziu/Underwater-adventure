using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightManager : MonoBehaviour
{
    private float ortographicSize;
    public float fillAmount;

    public float HorizontalCameraSize;
    public float VerticalCameraSize;
    public CameraController MyCameraController;
    public FirstBoss MyBoss;
    public Door EnterDoor;
    public Door ExitDoor;

    public Image BossHealthBar;
    public Image BossUI;

    void Start()
    {
        SetCameraSize();
    }

    void Update()
    {
        HandleBar();
    }

    private float MapHealthValue(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    private void HandleBar()
    {
        BossHealthBar.fillAmount = MapHealthValue(MyBoss.HealthPoints, 0, MyBoss.MaxHealthPoints, 0, 1);
    }

    private void SetCameraSize()
    {
        if (VerticalCameraSize * Camera.main.aspect < HorizontalCameraSize)
            ortographicSize = HorizontalCameraSize / (2 * Camera.main.aspect);
        else ortographicSize = VerticalCameraSize / 2;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            MyBoss.gameObject.SetActive(true);
            MyCameraController.SetCameraPosition(transform.position, ortographicSize, () => MyBoss.ActivateBoss());
            GetComponent<BoxCollider2D>().enabled = false;
            BossUI.gameObject.SetActive(true);
            EnterDoor.gameObject.SetActive(true);
        }
    }

    public void EndFight()
    {
        EnterDoor.gameObject.SetActive(false);
        ExitDoor.gameObject.SetActive(false);
        MyCameraController.SetDefaultPosition();
    }
}