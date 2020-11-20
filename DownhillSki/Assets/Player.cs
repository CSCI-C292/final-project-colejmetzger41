using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidBody;

    float _turnSpeed;
    float _sharpTurnSpeed;

    Vector3 _movement;

    float _maximumSpeed = 5f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _turnSpeed = 1.5f;
        _sharpTurnSpeed = 2.5f;

        _movement = new Vector3(1,0);

        Movement(_turnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Movement(_turnSpeed);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            Movement(_sharpTurnSpeed);
        }
    }

    void Movement(float speed) {
        //Make direction in the opposite direction from current.
        _movement.x *= -1;

        //_rigidBody.velocity = new Vector2(_movement.x * speed, _rigidBody.velocity.y);
        _rigidBody.velocity = _movement * speed;
    }

}
