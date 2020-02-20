using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move down at a speed of 3
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // when we leave the screen, destoy me
        if (transform.position.y <= -4f)
        {
            Destroy(this.gameObject);
        }
    }

    // ontrigger collison
    // only be collectable by the player
    //on collected, destroy and turn bool variable ino true
}
