using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemiesToSpawn;
    public Transform[] spawnPoints;
    public float spawnTime;
    public GameObject enemyPrefab;
    private GameObject tmpEnemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnTime);
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            for (int j = 0; j < enemiesToSpawn; j++)
                tmpEnemy = Instantiate(enemyPrefab,
                                spawnPoints[i].position,
                                Quaternion.identity);
        }
    }
}
