using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character
{
    [HideInInspector]
    public int MaxHealthPoints;

    public BossFightManager MyBossFightManager;
    public GameManager MyGameManager;
    public int HealthPoints;

    private void Start()
    {
        MaxHealthPoints = HealthPoints;
    }

    public override void TakeDamage()
    {
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            KillBoss();
        }
    }

    public virtual void KillBoss()
    {
        gameObject.SetActive(false);
        MyBossFightManager.EndFight();
        MyGameManager.DestroyProjectiles();
    }
}
