// Date   : 22.04.2018 19:40
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

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
