using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                // debug the floor position hit
                Debug.Log("Hit: " + hitInfo.point);
            }
            // create object at floor position
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            capsule.transform.position = hitInfo.point;
        }

    }
}
