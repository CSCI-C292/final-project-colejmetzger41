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

    string _turnType;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _turnSpeed = 1.5f;
        _sharpTurnSpeed = 2.0f;

        _movement = new Vector3(1,0);

        _turnType = "normal";
        StartCoroutine("Turn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _turnType = "normal";
            StartCoroutine("Turn");
            _movement.x *= -1;
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            _turnType = "sharp";
            StartCoroutine("Turn");
            _movement.x *= -1;
        }
    }

    IEnumerator Turn() 
    {
        float currentSpeed = _turnSpeed;
        if (_turnType.Equals("normal")) {
            for (float ft = -_turnSpeed; ft < _turnSpeed; ft += 0.05f) {
            _rigidBody.velocity = _movement * ft;

            yield return null;
        }
        }
        else {
            for (float ft = -_sharpTurnSpeed; ft < _sharpTurnSpeed; ft += 0.025f) {
            _rigidBody.velocity = _movement * ft;

            yield return null;
        }
        }
    }

}
