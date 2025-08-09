using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct SpawnData
{
    public GameObject EnemyToSpawn;
    public float TimeBeforeSpawn;
    public Transform SpawnPoint;
    public Transform EndPoint;
}

[System.Serializable]
public struct WaveData
{
    public float TimeBeforeWave;
    public List<SpawnData> EnemyData;
}

public class WaveManager : MonoBehaviour
{
    public List<WaveData> levelwaveData;

    private int enemiesRemaining = 0;
    private bool lastWaveSpawned = false;

    void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        for (int i = 0; i < levelwaveData.Count; i++)
        {
            WaveData currentWave = levelwaveData[i];
            foreach (SpawnData currentEnemyToSpawn in currentWave.EnemyData)
            {
                yield return new WaitForSeconds(currentEnemyToSpawn.TimeBeforeSpawn);
                SpawnEnemy(currentEnemyToSpawn.EnemyToSpawn, currentEnemyToSpawn.SpawnPoint, currentEnemyToSpawn.EndPoint);
            }
        }
        lastWaveSpawned = true;
        CheckForLevelEnd();
    }

    public void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint, Transform endPoint)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();
        enemy.Initialized(endPoint);

        enemiesRemaining++;
        enemy.OnEnemyDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath(Enemy enemy)
    {
        enemiesRemaining--;
        enemy.OnEnemyDeath -= HandleEnemyDeath;
        CheckForLevelEnd();
    }

    private void CheckForLevelEnd()
    {
        if (lastWaveSpawned && enemiesRemaining <= 0)
        {
            StartCoroutine(LoadNextLevelAfterDelay());
        }
    }

    private IEnumerator LoadNextLevelAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            
            Debug.Log("No more levels to load.");
        }
    }
}

