using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float cooldownSpawnerTime;
    private float cooldownSpawnerCurrentTime;

    [SerializeField] private float cooldownWaveTime;
    private float cooldownWaveCurrentTime;

    public Wave[] waves;
    private int currentEnemy;
    private int currentWave;
    private bool stopSpawn = false;


    public int countEnemies;
    public void Awake()
    {
        cooldownSpawnerCurrentTime = cooldownSpawnerTime;
        cooldownWaveCurrentTime = cooldownWaveTime;
        currentEnemy = 0;
        currentWave = 0;
        CalculateEnemies();
    }

    public void FixedUpdate()
    {
        if (stopSpawn) {
            cooldownWaveCurrentTime -= Time.deltaTime;
            if (cooldownWaveCurrentTime <= 0)
            {
                cooldownWaveCurrentTime = cooldownWaveTime;
                if (currentWave < waves.Length - 1)
                {
                    currentWave++;
                    currentEnemy = 0;
                    stopSpawn = false;
                }
            }
            else { return; }
            }

        if (cooldownSpawnerCurrentTime <= 0) {
            var soldiers = FindObjectsOfType<SoldierBase>();
            foreach (var item in soldiers)
            {
                item.prepared = true;
            }
            if (currentEnemy <= waves[currentWave].enemies.Length - 1)
            {
                Spawn(waves[currentWave].enemies[currentEnemy]);
                currentEnemy++;
            }
            else {
                stopSpawn = true;
            }
            cooldownSpawnerCurrentTime = cooldownSpawnerTime;
        }
        cooldownSpawnerCurrentTime -= Time.deltaTime;
    }

    private void Spawn(EnemyBase enemy) {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    public void StartSpawn() {
        stopSpawn = false;
    }

    private void CalculateEnemies() {
        for (int i = 0; i <= waves.Length-1; i++)
        {
            for (int j = 0; j <= waves[i].enemies.Length - 1; j++) {
                countEnemies++;
            }
        }
        GameManager.instance.CountEnemies += countEnemies;
    }
}
