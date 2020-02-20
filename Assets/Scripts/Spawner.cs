using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _powerupContainer;
    [SerializeField] private float _spawnTimer = 5f;
    private bool _playerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnPowerupRoutine()
    {
        //every 3 - 7 seconds spawn a powerup
        while (_playerAlive == true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 8f, 0);
            GameObject newPowerup = Instantiate(_powerupPrefab, spawnPos, Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(3f, 8f));
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_playerAlive == true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 8f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    public void OnPlayerDeath()
    {
        _playerAlive = false;
    }
}
