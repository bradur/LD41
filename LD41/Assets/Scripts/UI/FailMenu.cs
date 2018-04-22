// Date   : 22.04.2018 19:41
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class FailMenu : MonoBehaviour {

    void Start () {
    
    }

    void Update()
    {
        if (KeyManager.main.GetKeyUp(GameAction.Restart))
        {
            GameManager.main.RestartLevel();
        }
        if (KeyManager.main.GetKeyUp(GameAction.Quit))
        {
            Application.Quit();
        }
    }
}
