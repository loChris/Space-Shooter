﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    private Player _player;
    private Animator _anim;
    private AudioSource _explosionSound;

    void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
            Debug.LogError("Player is null");

        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.LogError("animator is null");
    }

    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if bottom of screen, respawn at top with a new random x position
        if (transform.position.y <= -8)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), 8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            
            _anim.SetTrigger("OnEnemyDeath");
            _explosionSound.Play();
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.ScorePoint(10);
            }
            _anim.SetTrigger("OnEnemyDeath");
            _explosionSound.Play();
            Destroy(GetComponent<Collider2D>());
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
    }
}
