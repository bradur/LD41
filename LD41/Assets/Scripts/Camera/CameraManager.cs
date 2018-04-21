// Date   : 21.04.2018 15:48
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public static CameraManager main;

    void Awake()
    {
        main = this;
    }


    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera topDownCamera;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera carSeatCamera;

    [SerializeField]
    private SimpleSmoothMouseLook mouseLook;

    [SerializeField]
    private GameObject miniMap;

    private int mainPriority = 10;
    private int secondaryPriority = 5;

    public void SwitchToCarSeatView()
    {
        carSeatCamera.Priority = mainPriority;
        topDownCamera.Priority = secondaryPriority;
        miniMap.SetActive(true);
        mouseLook.enabled = true;
    }

    public void SwitchToTopDown()
    {
        topDownCamera.Priority = mainPriority;
        carSeatCamera.Priority = secondaryPriority;
        mouseLook.enabled = false;
    }
}