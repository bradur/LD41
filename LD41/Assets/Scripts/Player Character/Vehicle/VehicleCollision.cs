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
            GroundSituation situation = collider.gameObject.GetComponent<GroundSituation>();
            situation.StartSituation(carSeatCamera);
            if (!situation.LevelEnd)
            {
                GameManager.main.SwitchToCarSeatView(!situation.LevelEnd);
                transform.rotation = collider.transform.rotation;
                transform.position = collider.transform.position;
            }
        }
    }
}
