using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int powerupID; // ID 0 = tripleshot, 1 = speed, 2 = shield
    [SerializeField] private AudioClip _powerupClip;

    void Update()
    {
        // powerup moves down at a variable speed
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if powerup leaves screen, destroy it
        if (transform.position.y <= -8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // getting the player component for script communication
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_powerupClip, transform.position);

            // check if not null to avoid crashes
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
