// Date   : 22.04.2018 23:04
// Project: DriveOrDie
// Author : bradur

using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


    void Update()
    {
        if (KeyManager.main.GetKeyUp(GameAction.Restart))
        {
            GameManager.main.RestartLevel();
        }
        if (KeyManager.main.GetKeyUp(GameAction.OpenMenu))
        {
            GameManager.main.CloseMenu();
        }
        if (KeyManager.main.GetKeyUp(GameAction.Quit))
        {
            Application.Quit();
        }
    }
}
