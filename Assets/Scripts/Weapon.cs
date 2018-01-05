using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool canShoot = true;
    private float FireRate;
    private float ProjectileSpeed;

    public string ProjectileName;
    public Transform Muzzle;
    public Transform ProjectileParent;
    public Projectile MyProjectile;
    public WeaponStats MyWeaponStats;

    private void Start()
    {
        FireRate = MyWeaponStats.FireRate;
        ProjectileSpeed = MyWeaponStats.ProjectileSpeed;
    }

    public void Aim(Vector3 target)
    {
        Vector3 diff = target - Muzzle.transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Muzzle.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    public bool Shoot()
    {
        if (canShoot)
        {
            StartCoroutine(ShootingCooldown());
            CreateProjectile();       
            return true;
        }
        return false;
    }

    private void CreateProjectile()
    {
        Projectile newProjectile = PoolManager.Instance.GetPooledObject(ProjectileName);
        newProjectile.SetSpeed(ProjectileSpeed);
        newProjectile.transform.position = Muzzle.position;
        newProjectile.transform.rotation = Muzzle.rotation;
        newProjectile.gameObject.SetActive(true);
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;
    }
}