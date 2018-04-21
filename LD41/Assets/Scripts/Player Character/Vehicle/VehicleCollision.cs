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


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "GroundSituation")
        {
            CameraManager.main.SwitchToCarSeatView();
        }
    }
}
