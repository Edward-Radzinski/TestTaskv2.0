using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseController : MonoBehaviour
{
    protected NavMeshAgent _myAgent;

    protected void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _myAgent.updateRotation = false;
        _myAgent.updateUpAxis = false;
    }

    protected virtual void NavMeshSetDestination(Vector3 moveDirection)
    {
        _myAgent.SetDestination(moveDirection);
    }
}
