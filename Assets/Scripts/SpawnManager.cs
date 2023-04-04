using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int poolSize;
    public float minSpawnDelay, maxSpawnDelay;

    private List<GameObject>[] enemyPools;

    void Start()
    {
        LoadEnemys();
        SpawnEnemy();
    }

    private void LoadEnemys()
    {
        enemyPools = new List<GameObject>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemyPools[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject enemy = Instantiate(enemyPrefabs[i], transform);
                enemy.SetActive(false);
                enemyPools[i].Add(enemy);
            }
        }
    }

    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = enemyPools[randomIndex].Find(e => !e.activeSelf);
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefabs[randomIndex], transform);
            enemyPools[randomIndex].Add(enemy);
        }
        enemy.transform.position = GetComponent<Transform>().transform.position;
        enemy.SetActive(true);

        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(randomDelay);
    }
}
