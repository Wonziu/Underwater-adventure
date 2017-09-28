using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEgg : Character
{
    public float SpawnCooldown;
    public int HealthPoints;

    public ChasingEnemyParent EnemyToSpawn;
    public PolygonCollider2D Area;

    void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(SpawnCooldown);

        ChasingEnemyParent o = Instantiate(EnemyToSpawn, Vector3.zero, Quaternion.identity);
        o.Enemy.transform.position = transform.position;
        o.EnemySight.points = Area.points;
        o.EnemySight.transform.position = Area.transform.position;

        gameObject.SetActive(false);
    }

    public override void KillCharacter()
    {
        if (HealthPoints > 0)
            HealthPoints--;
        else
            gameObject.SetActive(false);
    }
}