using UnityEngine;
using UnityEngine.UIElements;

public class FruitRandomSpawn : MonoBehaviour
{
    //[SerializeField] BoxCollider2D[] _boxCilliders;
    //private float _x, _y;
    [SerializeField] Transform[] _spawnPoints;

    private Vector2 GetPosition()
    {
        //int randomMesh = Random.Range(0, _boxCilliders.Length);
        //_x = Random.Range(
        //    _boxCilliders[randomMesh].transform.position.x - Random.Range(0, _boxCilliders[randomMesh].bounds.extents.x),
        //    _boxCilliders[randomMesh].transform.position.x + Random.Range(0, _boxCilliders[randomMesh].bounds.extents.x)
        //    );
        //_y = Random.Range(
        //    _boxCilliders[randomMesh].transform.position.y - Random.Range(0, _boxCilliders[randomMesh].bounds.extents.y),
        //    _boxCilliders[randomMesh].transform.position.y + Random.Range(0, _boxCilliders[randomMesh].bounds.extents.y)
        //    );

        int rand = Random.Range(0, _spawnPoints.Length);
        return new Vector2(_spawnPoints[rand].position.x, _spawnPoints[rand].position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            transform.position = GetPosition();
        }
    }
}
