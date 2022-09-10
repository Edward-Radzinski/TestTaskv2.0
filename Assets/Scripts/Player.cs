using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : BaseController
{
    private Camera _camera;
    [SerializeField] private LayerMask _clickableMask;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private EventSystem _eventSystem;

    [Header("Player stats")]
    [SerializeField] private int _hp = 100;
    private int _getDamage = 10;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, _clickableMask);
            //if (EventSystem.current.IsPointerOverGameObject()) return;
            if (_eventSystem.currentSelectedGameObject != null) return;
            if (hit)
            {
                _myAgent.isStopped = false;
                NavMeshSetDestination(hit.point);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _myAgent.isStopped = true;
            _myAgent.velocity = Vector2.zero;

            _hp -= _getDamage;
            _hpSlider.value = _hp;
            if (_hp <= 0) Destroy(this.gameObject);

            transform.position = _spawnPoint.position;
        }
    }
}
