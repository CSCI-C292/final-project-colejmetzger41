using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrailController : MonoBehaviour {

    //I used unity answers example code for a large portion of the trail implementation
    //https://answers.unity.com/questions/1343711/trail-effect-for-non-moving-object.html

    public float lifetime = 5f; //lifetime of a point on the trail

    public float minimumVertexDistance = 0.1f; //minimum distance moved before a new point is solidified.

    public Vector3 velocity; //direction the points are moving

    LineRenderer line;
    //position data
    List<Vector3> points;
    Queue<float> spawnTimes = new Queue<float>(); 

    Vector3 _startingPoint;

    // Use this for initialization
    void Awake () {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = true;
        line.numCapVertices = 5;
        _startingPoint = transform.position;
        _startingPoint.y += 0.15f;
        _startingPoint.x += 0.15f;
        points = new List<Vector3>() { _startingPoint }; //indices 1 - end are solidified points, index 0 is always transform.position
        line.SetPositions(points.ToArray());
    }   

    void AddPoint(Vector3 position) {
        points.Insert(1, position);
        spawnTimes.Enqueue(Time.time);
    }

    void RemovePoint() {
        spawnTimes.Dequeue();
        points.RemoveAt(points.Count - 1); //remove corresponding oldest point at the end
    }

    // Update is called once per frame
    void Update () {

        _startingPoint = transform.position;
        _startingPoint.y += 0.15f;
        _startingPoint.x += 0.15f;

        //cull based on lifetime
        while(spawnTimes.Count > 0 && spawnTimes.Peek() + lifetime < Time.time) {
            RemovePoint();
        }

        //move positions
        Vector3 diff = -velocity * Time.deltaTime;
        for(int i = 1; i < points.Count; i++) {
            points[i] += diff;
        }

        //add new point
        if (points.Count < 2 || Vector3.Distance(_startingPoint, points[1]) > minimumVertexDistance) {
            AddPoint(_startingPoint);
        }

        //update index 0;
        points[0] = _startingPoint;

        //save result
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
}