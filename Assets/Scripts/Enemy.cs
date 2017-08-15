
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Vector2[] Waypoints;
    public bool Cyclic;
    public float WaitTime;
    [Range(0, 3)]
    public float easeAmount;

    private float percentBetweenwaypoints;
    private int fromWaypointIndex;
    private float nextMoveTime;

    private void Start()
    {

    }

    private void Update()
    {
        Vector2 velocity = MoveTowardsWaypoint();
        transform.Translate(velocity);
        Flip(velocity);
    }

    private void Flip(Vector2 velocity)
    {
        if (velocity.x > 0 && FacingRight || velocity.x < 0 && !FacingRight)
        {
            ChangeDirection();
        }
    }

    private float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    private Vector2 MoveTowardsWaypoint()
    {
        if (Time.time < nextMoveTime)
            return Vector2.zero;

        fromWaypointIndex %= Waypoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % Waypoints.Length;
        float distanceBetweeenWaypoints = Vector2.Distance(Waypoints[fromWaypointIndex], Waypoints[toWaypointIndex]);

        percentBetweenwaypoints += Time.deltaTime * MovementSpeed / distanceBetweeenWaypoints;
        percentBetweenwaypoints = Mathf.Clamp01(percentBetweenwaypoints);
        float easedPercent = Ease(percentBetweenwaypoints);

        Vector2 newPos = Vector2.Lerp(Waypoints[fromWaypointIndex], Waypoints[toWaypointIndex], easedPercent);

        if (percentBetweenwaypoints >= 1)
        {
            percentBetweenwaypoints = 0;
            fromWaypointIndex++;

            if (!Cyclic)
                if (fromWaypointIndex >= Waypoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    System.Array.Reverse(Waypoints);
                }
            nextMoveTime = Time.time + WaitTime;
        }

        return newPos - new Vector2(transform.position.x, transform.position.y);
    }
}
