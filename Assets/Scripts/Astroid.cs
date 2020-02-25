using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] private float _speed = 19f;
    [SerializeField] private GameObject _explosionPrefab;
    private Spawner _spawnManager;
    private AudioSource _explosionSound;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawner").GetComponent<Spawner>();
        _explosionSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }

    // check for laser collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            _explosionSound.Play();
            Instantiate(_explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }
    }
}
