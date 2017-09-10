using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBoss : Character
{
    private IBossState currentState;
    public IBossState nextState;
    private bool isSeen;
    [HideInInspector]
    public Vector3 ChargeDirection;
    public Vector3 ShootingPosition;
    public int MaxChargesCount;
    public Weapon MyWeapon;

    public Player MyPlayer;

    public bool isCharging;

    private void Start()
    {
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Execute();

        Debug.Log(currentState);
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

        ChargeDirection = Vector3.Normalize(MyPlayer.transform.position - transform.position) * MovementSpeed;

        while (isSeen)     
            yield return null;

        ChargeDirection = Vector3.zero;

        yield return new WaitForSeconds(0.25f);
        isCharging = false;   
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            MyPlayer.KillPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BossArea")
            isSeen = false;
    }
}