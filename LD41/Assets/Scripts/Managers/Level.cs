// Date   : 22.04.2018 11:11
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    [SerializeField]
    private int timeLimit = 40;

    [SerializeField]
    private Transform playerPosition;

    void Start () {
    
    }

    public void Initialize()
    {
        GameManager.main.SetTimeLimit(timeLimit);
        GameManager.main.PlacePlayer(playerPosition);
    }

    void Update () {
    
    }
}
