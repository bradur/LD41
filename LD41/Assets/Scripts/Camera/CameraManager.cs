// Date   : 21.04.2018 15:48
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera topDownCamera;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera carSeatCamera;

    private int mainPriority = 10;
    private int secondaryPriority = 5;

    public void SwitchToCarSeatView()
    {
        carSeatCamera.Priority = mainPriority;
        topDownCamera.Priority = secondaryPriority;
    }

    public void SwitchToTopDown()
    {
        topDownCamera.Priority = mainPriority;
        carSeatCamera.Priority = secondaryPriority;
    }
}
