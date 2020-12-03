using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tree : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] RuntimeData _runtimeData;
    
    // Update is called once per frame
    void Update()
    {
        //Delete tree if it is off the screen
        if (transform.position.y > 7) {
            Destroy(gameObject);
        }
        transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") {
            _runtimeData.EndTime = Time.time;
            _runtimeData.Score = (int)(_runtimeData.EndTime - _runtimeData.StartTime);

            if (_runtimeData.Score > _runtimeData.HighScore) {
                _runtimeData.HighScore = _runtimeData.Score;
            }

            SceneManager.LoadScene("GameOver");
        }
    }
}
