using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBoss : Character
{
    private bool isSeen;
    private IBossState currentState;

    [HideInInspector]
    public int ShootingPositionIndex;
    [HideInInspector]
    public Vector3 NextShootingPosition;
    [HideInInspector]

    public Vector3 ChargeDirection;
    public Weapon MyWeapon;
    public List<Vector3> ShootingPositions;
    public IBossState nextState;
    public bool isCharging;
    public int MaxChargesCount;

    private void Start()
    {
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.ExecuteInFixed();
    }

    public void ActivateBoss()
    {
        ChangeState(new ChargingState());
    }

    public void MoveBossToStartPosition()
    {

    }

    public void ChangeState(IBossState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter(this);
    }

    public IEnumerator ChargeAtPlayer()
    {
        isCharging = true;
        isSeen = true;

        ChargeDirection = Vector3.Normalize(Target.transform.position - transform.position) * MovementSpeed;

        while (isSeen)
            yield return null;

        ChargeDirection = Vector3.zero;

        yield return new WaitForSeconds(0.25f);
        isCharging = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BossArea")
            isSeen = false;
    }

    public void GetNextShootingPosition()
    {
        ShootingPositionIndex = (ShootingPositionIndex + 1) % ShootingPositions.Count;

        NextShootingPosition = ShootingPositions[ShootingPositionIndex];
        Debug.Log(ShootingPositionIndex);
    }
}