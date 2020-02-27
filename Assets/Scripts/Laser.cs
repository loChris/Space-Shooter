using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private bool _isEnemyLaser = false;

    void Update()
    {
       if (_isEnemyLaser == false)
           MoveUp();
       else
           MoveDown();
    }

    void MoveUp()
    {
        // translate laser upwards
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));

        // if laser position is greater than 8 on the y, destroy it
        if (transform.position.y >= 8f)
        {
            //check if this object has a parent - if so, destroy it
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        // translate laser upwards
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));

        // if laser position is greater than 8 on the y, destroy it
        if (transform.position.y <= -8f)
        {
            //check if this object has a parent - if so, destroy it
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void AssignLaserToEnemy()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null)
                player.Damage(0.5f);
        }
    }
}
