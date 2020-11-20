using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] float _speed;

    
    // Update is called once per frame
    void Update()
    {
        //Delete tree if it is off the screen
        if (transform.position.y > 7) {
            Destroy(gameObject);
        }
        transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
    }
}
