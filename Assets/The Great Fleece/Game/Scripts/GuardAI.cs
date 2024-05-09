using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public Transform currentTarget;
    private NavMeshAgent _agent;
    private int currentWaypoint = 0;
    private bool _reverseLane = false;
    private bool _targetReach = false; // Halt the Update method
    private bool _idle = false;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0 && wayPoints[0] != null)
        {
            currentTarget = wayPoints[0];
            _agent.SetDestination(currentTarget.position);
        }
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && currentTarget != null)
        {
            if (wayPoints.Count == 1)
            {
                _animator.SetBool("Walk", false);
            }
            else
            {
                if (Vector3.Distance(transform.position, currentTarget.position) < 1f && _targetReach == false)
                {
                    _targetReach = true;
                    // Checking the route
                    if (currentWaypoint == 0)
                    {
                        _reverseLane = false;
                    }
                    else if (currentWaypoint == wayPoints.Count - 1)
                    {
                        _reverseLane = true;
                    }

                    _idle = (currentWaypoint == 0 || currentWaypoint == wayPoints.Count - 1) ? true : false;

                    if (_idle)
                    {
                        StartCoroutine(WaitBeforeMoving());
                    }
                    else
                    {
                        MoveToTheNextWayPoint();
                    }
                }
            }
        }
    }
    private IEnumerator WaitBeforeMoving()
    {
        _animator.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        MoveToTheNextWayPoint();
    }

    private void MoveToTheNextWayPoint()
    {
        _animator.SetBool("Walk", true);
        // Implementing the route
        if (!_reverseLane)
        {
            ++currentWaypoint;
            if (wayPoints[currentWaypoint] != null)
            {
                currentTarget = wayPoints[currentWaypoint];
                _agent.SetDestination(currentTarget.position);
            }
        }
        else
        {
            --currentWaypoint;
            if (wayPoints[currentWaypoint] != null)
            {
                currentTarget = wayPoints[currentWaypoint];
                _agent.SetDestination(currentTarget.position);
            }
        }
        _targetReach = false;
    }
}
