using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 8f, 0);
            Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
}
