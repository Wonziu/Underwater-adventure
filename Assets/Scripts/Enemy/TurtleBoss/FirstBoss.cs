using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBoss : Boss
{
    private bool isSeen;
    private IBossState currentState;

    [HideInInspector]
    public int ShootingPositionIndex;
    [HideInInspector]
    public Vector3 NextPosition;
    [HideInInspector]
    public Vector3 ChargeDirection;

    public List<EnemyEgg> Eggs;
    public Weapon MyWeapon;
    public List<Vector3> ShootingPositions;
    public IBossState NextState;

    public bool IsCharging;
    public bool IsSpawning;

    public int ChargeMovementSpeed;
    public int BulletsAmount;
    public int MaxChargesCount;
    public int SpawnCount;

    public float EnemySpawnDelay;
    public float ChargeDelay;

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

    public void ChangeState(IBossState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter(this);
    }

    public IEnumerator ChargeAtPlayer()
    {
        IsCharging = true;
        isSeen = true;

        ChargeDirection = Vector3.Normalize(Target.transform.position - transform.position) * ChargeMovementSpeed;

        while (isSeen)
            yield return null;

        ChargeDirection = Vector3.zero;

        yield return new WaitForSeconds(ChargeDelay);
        IsCharging = false;
    }

    public void Flip(Vector2 dir)
    {
        if (dir.x > 0 && FacingLeft || dir.x < 0 && !FacingLeft)
        {
            ChangeDirection();
        }
    }

    public IEnumerator SpawnEggs()
    {
        IsSpawning = true;
        int i = 0;

        foreach (var enemyEgg in Eggs)
        {
            if (i == SpawnCount)
                break;

            enemyEgg.gameObject.SetActive(true);
            yield return new WaitForSeconds(EnemySpawnDelay);
            i++;
        }

        yield return new WaitForSeconds(EnemySpawnDelay);
        IsSpawning = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BossArea")
            isSeen = false;
    }

    public void GetNextPosition()
    {
        ShootingPositionIndex = (ShootingPositionIndex + 1) % ShootingPositions.Count;

        NextPosition = ShootingPositions[ShootingPositionIndex];
    }
}