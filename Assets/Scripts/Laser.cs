using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;

    void Update()
    {
        // translate laser upwards
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

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
}
