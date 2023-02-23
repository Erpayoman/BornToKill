
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] int enemiesOnLevel = 10;    
    [SerializeField] Text countUI;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform enemyParent;

    int enemiesToRespawn;
    float timeToSpawn = 0.5f;
    float currentTime = 0.0f;

    public int EnemiesOnLevel { get { return enemiesOnLevel; } private set { enemiesOnLevel = value; } }
    public int EnemiesToRespawn { get { return enemiesToRespawn; } set { enemiesToRespawn = value; } }


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
