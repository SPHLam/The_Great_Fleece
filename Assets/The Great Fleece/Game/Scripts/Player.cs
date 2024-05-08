using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // if left click
        if (Input.GetMouseButtonDown(0)) // 0 - left, 1 - right, 2 - scroll view
        {
            // case a ray from mouse position
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                // set the position of the Player
                _agent.SetDestination(hitInfo.point);
            }
            
        }

    }
}
