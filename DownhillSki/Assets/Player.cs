using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidBody;

    [SerializeField] float _turnSpeed;
    [SerializeField] float _sharpTurnSpeed;

    Vector3 _movement;

    float _maximumSpeed = 5f;

    string _turnType;

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] GameObject _bonusText;

    void Awake() {
        _bonusText.GetComponent<Text>().enabled = false;
        _runtimeData.Score = 0;
        _runtimeData.Bonus = 0;
    }

    void Start()
    {
        _runtimeData.StartTime = Time.time;

        _rigidBody = GetComponent<Rigidbody2D>();

        _movement = new Vector3(1,0);

        _turnType = "normal";
        StartCoroutine("Turn");
    }

    // Update is called once per frame
    void Update()
    {
        ///Below is commented out code where I was trying a press and hold method to do sharp turning.

        /*_turnType = "normal";
        if (Input.GetKeyDown(KeyCode.Space) && _keyPressed == false) {
            //StopCoroutine("SpeedUpTurn");
            _keyDownTime = Time.time;
            _keyPressed = true;
            StartCoroutine("Turn");
        }
        if (Time.time - _keyDownTime >= _holdTimeForSharpTurn) {
            StopCoroutine("Turn");
            //StartCoroutine("SpeedUpTurn");
            _rigidBody.velocity = _movement * _sharpTurnSpeed;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            _keyPressed = false;
            _movement.x *= -1;
        }*/


        
        if (Input.GetKeyDown(KeyCode.Space)) {
            _turnType = "normal";
            StartCoroutine("Turn");
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            _turnType = "sharp";
            StartCoroutine("Turn");
        }

        GetScore();
        
    }

    void GetScore() {
        _runtimeData.EndTime = Time.time;
        _runtimeData.Score = (int)((_runtimeData.EndTime - _runtimeData.StartTime)*10);
        _runtimeData.Score += _runtimeData.Bonus;
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
            for (float ft = -_sharpTurnSpeed; ft <= _sharpTurnSpeed; ft += 0.035f) {
                _rigidBody.velocity = _movement * ft;

                yield return null;
            }
        }
        _movement.x *= -1;
    }

    //Sharp turn try. Didn't work in end.
    /*IEnumerator SpeedUpTurn() 
    {
        for (float ft = _rigidBody.velocity.x; ft < _sharpTurnSpeed; ft += 0.05f) {
            _rigidBody.velocity = _movement * ft;

            yield return null;
        }
        _movement.x *= -1;
    }*/

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.GetType() == typeof(BoxCollider2D)) {

            if (_runtimeData.Score > _runtimeData.HighScore) {
                _runtimeData.HighScore = _runtimeData.Score;
            }

            SceneManager.LoadScene("GameOver");
        }

        else if (collider.GetType() == typeof(CircleCollider2D)) {
            //Add bonus score and show bonus text as well as tree shadow.
            _runtimeData.Bonus += 10;
            _bonusText.GetComponent<Text>().enabled = true;
            _bonusText.GetComponent<Text>().color = Color.black;
            StartCoroutine(FadeOutRoutine());

            Transform shadow = collider.transform.Find("TreeShadow");
            shadow.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Source used for Coroutine code for fading out a text:
    // https://answers.unity.com/questions/1312063/fade-out-text.html
    IEnumerator FadeOutRoutine()
         { 
             _bonusText.GetComponent<Text>().text = "Bonus! +" + _runtimeData.Bonus;
             Text text = _bonusText.GetComponent<Text>();
             float fadeOutTime = 1f;
             Color originalColor = text.color;
             for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
             {
                 text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeOutTime));
                 yield return null;
             }
         }
    }

}
