using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 8f, 0);
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        // other = player, destroy me and damage player
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
