using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEgg : Character
{
    public float SpawnCooldown;
    public GameObject EnemyToSpawn;
    public int HealthPoints;

    void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(SpawnCooldown);

        Instantiate(EnemyToSpawn, transform.position, Quaternion.identity);

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
