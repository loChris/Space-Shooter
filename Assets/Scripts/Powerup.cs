using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    // Update is called once per frame
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

            // check if not null to avoid crashes
            if (player != null)
            {
                // call method from player script and destroy this object
                player.TripleShotActive();
                Destroy(this.gameObject);
            }
        }
    }
}
