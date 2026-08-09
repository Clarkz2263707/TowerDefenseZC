using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//Summary
//Handles the waves on the various levels that you can customize via the inspector.
//summary

[System.Serializable]
//gets the spawndata needed for the enemies
public struct SpawnData
{
    public GameObject EnemyToSpawn;
    public float TimeBeforeSpawn;
    public Transform SpawnPoint;
    public Transform EndPoint;
}

[System.Serializable]
//gathers the established in the inspector time before wave and enemy data
public struct WaveData
{
    public float TimeBeforeWave;
    public List<SpawnData> EnemyData;
}
//the actual wave manager and the operations needed to spawn waves.
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
    //starts the wave using a for statement, waits for seconds, and uses the level wave data which is set in inspector.
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
    //handles spawning of enemies
    public void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint, Transform endPoint)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();
        enemy.Initialized(endPoint);

        enemiesRemaining++;
        enemy.OnEnemyDeath += HandleEnemyDeath;
    }
    //handles enemy death and checks if anymore waves are present
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
    //loads next level after a short delay
    private IEnumerator LoadNextLevelAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        LoadNextLevel();
    }
    //handles the loading of next level.
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

