using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _targetDestination;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
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
            
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                // set the position of the Player
                _agent.SetDestination(hitInfo.point);
                _targetDestination = hitInfo.point;
                _animator.SetBool("Walk", true);
            }
            
        }
        // check if the distance between player and target destination == 0
        // stop walking, back to idle

        if (Vector3.Distance(transform.position, _targetDestination) < 1f)
        {
            _animator.SetBool("Walk", false);
        }

    }
}
