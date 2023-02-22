
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public int enemiesOnLevel = 10;    
    public Text countUI;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public Transform enemyParent;

    [HideInInspector]
    public int enemiesToRespawn;

    float timeToSpawn = 0.5f;
    float currentTime = 0.0f;
    // Use this for initialization

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start ()
    {
        enemiesToRespawn = enemiesOnLevel;
        countUI.text = enemiesToRespawn.ToString();
        GameManager.EnemiesAlive = enemiesOnLevel;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemiesToRespawn == 0) return;
        currentTime += Time.deltaTime;

        if(currentTime > timeToSpawn)
        {
            SpawnEnemy();
            currentTime = 0.0f;
            timeToSpawn = Random.Range(10f, 15f);
        }
	}

    private void SpawnEnemy()
    {
        int indexSpawnPoint = Random.Range(0, spawnPoints.Length);
        int indexEnemyPrefab = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[indexEnemyPrefab], spawnPoints[indexSpawnPoint].position,
                    spawnPoints[indexSpawnPoint].transform.rotation, enemyParent);
        enemiesToRespawn--;
        
    }
   
}
