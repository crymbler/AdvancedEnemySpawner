using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private float _spawnDelay;

    private WaitForSeconds _delay;
    private WaypointMovement _target;
    private Coroutine _spawnRoutine;

    private void Start()
    {
        _target = GetComponentInChildren<WaypointMovement>();

        _delay = new WaitForSeconds(_spawnDelay);

        _spawnRoutine = StartCoroutine(SpawnEnemy());
    }

    private void OnDestroy() => StopCoroutine(_spawnRoutine);

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnemyMover enemy = Instantiate<EnemyMover>(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetDirection(_target);

            yield return _delay;
        }
    }
}