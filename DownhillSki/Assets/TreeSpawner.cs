using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeSpawner : MonoBehaviour
{
    float _xMin;
    float _xMax;
    float _ySpawn;

    [SerializeField] GameObject _treePrefab;

    [SerializeField] GameObject _smallTreePrefab;

    [SerializeField] RuntimeData _runtimeData;
    // Start is called before the first frame update
    void Start()
    {
        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        _ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0,-0.15f,0)).y;

        InvokeRepeating("SpawnTrees", 0, 0.4f);

        _runtimeData.StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTrees() {
        float randX = Random.Range(_xMin, _xMax);
        float randXSmall = Random.Range(_xMin, _xMax);

        Instantiate(_treePrefab, new Vector3(randX, _ySpawn, 0), Quaternion.identity);
        Instantiate(_smallTreePrefab, new Vector3(randXSmall, _ySpawn, 0), Quaternion.identity);
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
