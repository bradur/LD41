// Date   : 21.04.2018 14:53
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class DirtTrail : MonoBehaviour {

    private Transform target;
    private bool trailing = false;
    private Vector3 newPosition;

    [SerializeField]
    private bool followX = true;

    [SerializeField]
    private bool followY = false;

    [SerializeField]
    private bool followZ = true;

    [SerializeField]
    private TrailRenderer trail;

    public void Initialize (Transform target, Transform parent)
    {
        this.target = target;
        trailing = true;
        trail.enabled = true;
    }

    void Start () {
    
    }

    public void Stop()
    {
        trailing = false;
    }

    void SetPosition()
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

    void Update () {
        if (trailing)
        {
            SetPosition();
        }
    }
}
