using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // variable to hold the object you want to look at
    public Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
