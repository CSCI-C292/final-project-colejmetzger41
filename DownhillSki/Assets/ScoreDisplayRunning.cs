using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayRunning : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] GameObject _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText() 
    {
        _scoreText.GetComponent<Text>().text = "Score: " + _runtimeData.Score;
    }
}
