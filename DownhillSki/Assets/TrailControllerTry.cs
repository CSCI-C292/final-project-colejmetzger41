using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControllerTry : MonoBehaviour
{

    LineRenderer _line;

    Queue<Vector3> _points;

    List<Vector3> _convertedPoints;
    void Awake() 
    {
        _line = GetComponent<LineRenderer>();
        _points = new Queue<Vector3>();
        _points.Enqueue(transform.position);
        _line.useWorldSpace = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _convertedPoints = new List<Vector3>();
        _convertedPoints.Add(new Vector3(1,2));
        _convertedPoints.Add(new Vector3(1,2));

        _line.SetPositions(_convertedPoints.ToArray());
    }

    void AddPoint() {

    }

    void RemoveLastPoint() {
        _points.Dequeue();
    }
}
