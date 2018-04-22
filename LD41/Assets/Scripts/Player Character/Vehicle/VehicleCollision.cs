// Date   : 21.04.2018 15:52
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class VehicleCollision : MonoBehaviour {

    void Start () {
    
    }

    void Update () {
    
    }

    [SerializeField]
    private Transform carSeatCamera;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "GroundSituation")
        {
            transform.rotation = collider.transform.rotation;
            CameraManager.main.SwitchToCarSeatView();
            collider.gameObject.GetComponent<GroundSituation>().StartSituation(carSeatCamera);
        }
    }
}
