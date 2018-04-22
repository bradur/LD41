// Date   : 21.04.2018 19:34
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour {

    [SerializeField]
    private Camera targetCamera;

    void Update () {
        transform.LookAt(
            transform.position + targetCamera.transform.rotation * Vector3.forward,
            targetCamera.transform.rotation * Vector3.up
        );
    }
}
