﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;

    public LayerMask MyLayerMask;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void Update()
    {
        CheckCollisions(speed * Time.deltaTime);
    }

    private void CheckCollisions(float moveDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, moveDistance, MyLayerMask);

        if (hit.collider != null)
            OnHit(hit);
    }

    private void OnHit(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Enemy" || hit.collider.tag == "Boss")
            hit.collider.GetComponent<Character>().TakeDamage();
        else if (hit.collider.tag == "Player")
            hit.transform.GetComponent<Player>().TakeDamage();

        gameObject.SetActive(false);
    }
}