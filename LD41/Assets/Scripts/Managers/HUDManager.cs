// Date   : 22.04.2018 11:13
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

    void Start () {
    
    }

    void Update () {
    
    }

    [SerializeField]
    private HUDTimeLimit hudTimeLimit;

    [SerializeField]
    private GameObject mainMenu;

    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }


    public void SetTimeLimit(int timeLimit)
    {
        hudTimeLimit.gameObject.SetActive(true);
        hudTimeLimit.Initialize(timeLimit);
    }
}
