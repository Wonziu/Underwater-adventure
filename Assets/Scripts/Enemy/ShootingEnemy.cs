using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Character
{
    public LayerMask PlayerLayerMask;

    public Weapon MyWeapon;

    private void Update()
    {
        if (Target != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Target.transform.position - transform.position, Single.PositiveInfinity, PlayerLayerMask);

            if (hit.transform == Target.transform)
            {
                MyWeapon.Aim(Target.transform.position);

                MyWeapon.Shoot();
            }
        }
    }
}
