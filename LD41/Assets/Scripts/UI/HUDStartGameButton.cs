// Date   : 22.04.2018 12:10
// Project: LD41
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDStartGameButton : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    public void StartGameClick()
    {
        GameManager.main.NextLevel();
    }

}
