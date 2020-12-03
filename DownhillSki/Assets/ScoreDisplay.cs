using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] GameObject _scoreText;

    [SerializeField] GameObject _highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScoreText() 
    {
        _scoreText.GetComponent<Text>().text = "Score: " + _runtimeData.Score;
        _highScoreText.GetComponent<Text>().text = "HighScore: " + _runtimeData.HighScore;
    }
}
