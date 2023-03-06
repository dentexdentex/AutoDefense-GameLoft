using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;

    public List<GameObject> enemyPool;
    private GameObject enemy;
    void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < 5; i++) // pool size
        { 
            enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject enemy = null;
            for (int i = 0; i < enemyPool.Count; i++)
            {
                if (!enemyPool[i].activeInHierarchy)
                {
                    enemy = enemyPool[i];
                    break;
                }
            }
            if (enemy == null)
            {
                enemy = Instantiate(enemyPrefab);
                enemyPool.Add(enemy);
            }
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public List<Transform> GetEnemyPool()
    {
        return enemyPool.Select(enemy => enemy.transform).ToList(); //erişemiyor yok edilince
    }
}