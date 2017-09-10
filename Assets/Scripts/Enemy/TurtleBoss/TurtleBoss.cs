using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBoss : Character
{
    private ITurtleBossState currentState;
    public Player myPlayer;
    private bool isSeen;

    private Vector3 dir;

    public bool isCharging;

    private void Start()
    {
        ChangeState(new ChargingState());
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }

    private void FixedUpdate()
    {
        MyRigidbody2D.velocity = dir;
    }

    public void ChangeState(ITurtleBossState newState)
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

        dir = Vector3.Normalize(myPlayer.transform.position - transform.position) * MovementSpeed;

        while (isSeen)     
            yield return null;

        dir = Vector3.zero;

        yield return new WaitForSeconds(0.25f);
        isCharging = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            myPlayer = coll.GetComponent<Player>();
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BossArea")
            isSeen = false;
    }
}

