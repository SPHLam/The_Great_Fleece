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
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0 && wayPoints[0] != null)
        {
            currentTarget = wayPoints[0];
            _agent.SetDestination(currentTarget.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && currentTarget != null)
        {
            if (Vector3.Distance(transform.position, currentTarget.position) < 1f)
            {
                if (currentWaypoint == 0)
                {
                    _reverseLane = false;
                }
                else if (currentWaypoint == wayPoints.Count - 1)
                {
                    _reverseLane = true;
                }

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

            }
        }
    }
}
