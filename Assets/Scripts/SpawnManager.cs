using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public bool spawnEnemies;
    public int poolSize;
    public float minSpawnDelay, maxSpawnDelay;

    private List<GameObject>[] enemyPools;

    void Start()
    {
        LoadEnemies();
        StartCoroutine(SpawnEnemy());
    }

    private void LoadEnemies()
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

    IEnumerator SpawnEnemy()
    {
        while(spawnEnemies == true){
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = enemyPools[randomIndex].Find(e => !e.activeSelf);
            if (enemy == null)
            {
                enemy = Instantiate(enemyPrefabs[randomIndex], transform);
                enemyPools[randomIndex].Add(enemy);
            }
            
            enemy.transform.position = GetComponent<Transform>().transform.position;
            if(enemy.name.Equals("Raven(Clone)")){
                int r = Random.Range(1,3);
                if(r==1)
                    enemy.transform.position += new Vector3(0,0.84f,0);
                if(r==2)
                    enemy.transform.position += new Vector3(0, 1.21f, 0);
            }
            enemy.SetActive(true);
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);
        }
    }

}
