// Date   : 22.04.2018 19:42
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class SuccessMenu : MonoBehaviour {

    void Update()
    {
        if (KeyManager.main.GetKeyUp(GameAction.OK))
        {
            GameManager.main.NextLevel();
        }
        if (KeyManager.main.GetKeyUp(GameAction.Quit))
        {
            Application.Quit();
        }
    }
}
