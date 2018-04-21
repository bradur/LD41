// Date   : 18.10.2017 23:19
// Project: Kajam 1
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FollowCamera : MonoBehaviour
{


    [SerializeField]
    private bool followX = false;

    [SerializeField]
    private bool followY = false;

    [SerializeField]
    private bool followZ = false;

    [SerializeField]
    private Transform target;

    private Vector3 newPosition;

    private void Start()
    {

    }

    private void Update()
    {
        newPosition = transform.position;
        if (followX)
        {
            newPosition.x = target.position.x;
        }
        if (followY)
        {
            newPosition.y = target.position.y;
        }
        if (followZ)
        {
            newPosition.z = target.position.z;
        }

        transform.position = newPosition;
    }

}
