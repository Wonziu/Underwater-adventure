using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float FireRate;
    public float Damage;
    public float ProjectileSpeed;
    public Transform Muzzle;

    public Projectile MyProjectile;

    private bool canShoot = true;

    public void Aim(Vector3 target)
    {
        Vector3 diff = target - Muzzle.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Muzzle.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            StartCoroutine(ShootingCooldown());

            Projectile newProjectile = Instantiate(MyProjectile, Muzzle.position, Muzzle.rotation);
            newProjectile.SetSpeed(ProjectileSpeed);
        }
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;
    }
}