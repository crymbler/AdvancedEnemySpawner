using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Queue<Transform> _points = new Queue<Transform>();
    private Transform _target;

    private void Start()
    {
        transform.position = _path.position;

        foreach (Transform point in _path)
            _points.Enqueue(point);

        GetNextPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            GetNextPoint();
    }

    private void GetNextPoint()
    {
        _target = _points.Dequeue();

        _points.Enqueue(_target);
    }
}
