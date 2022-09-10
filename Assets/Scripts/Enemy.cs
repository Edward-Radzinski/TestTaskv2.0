using UnityEngine;

public class Enemy : BaseController
{
    private bool _pursuit = false;
    private Transform _playerTemp;

    private float _timer = 0;
    [SerializeField] private float _timeBeforeMovement;
    [SerializeField] private int _randomPoint = 0;
    [SerializeField] private Transform[] _wayPoints;

    private void Update()
    {
        if (_pursuit) NavMeshSetDestination(_playerTemp.transform.position);
        else
        {
            NavMeshSetDestination(_wayPoints[_randomPoint].position);
            if (Time.time > _timer)
            {
                _timer = Time.time + _timeBeforeMovement;
                _randomPoint = Random.Range(0, _wayPoints.Length);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _pursuit = true;
            _playerTemp = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()) _pursuit = false;
        
    }
}
