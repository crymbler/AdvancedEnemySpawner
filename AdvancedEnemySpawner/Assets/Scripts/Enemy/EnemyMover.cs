using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Transform _target;

    private void Update() => transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

    public void SetDirection(WaypointMovement target) => _target = target.transform;
}