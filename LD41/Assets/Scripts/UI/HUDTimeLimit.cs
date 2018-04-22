// Date   : 22.04.2018 11:14
// Project: LD41
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTimeLimit : MonoBehaviour
{

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    private int milliSeconds;
    private bool running = false;

    public void Initialize(int timeLimit)
    {
        milliSeconds = timeLimit * 1000;
        running = true;
        SetTime(0);
    }

    private void SetTime(int millisecondsSince)
    {
        if (milliSeconds >= 0)
        {
            milliSeconds -= millisecondsSince;
        }
        else
        {
            running = false;
            milliSeconds = 0;
            GameManager.main.TimeLimitReached();
        }
        int minutes = milliSeconds / 60000;
        int seconds = milliSeconds % 60000 / 1000;
        int hectas = milliSeconds % 60000 % 1000;

        string minuteString = (minutes < 10) ? ("0" + minutes) : minutes + "";
        string secondString = (seconds < 10) ? ("0" + seconds) : seconds + "";
        string hectaString = (hectas < 10) ? ("00" + hectas) : ((hectas < 100) ? ("0" + hectas) : hectas + "");

        txtComponent.text = minuteString + ":" + secondString + "." + hectaString;
    }

    private void Update()
    {
        if (running)
        {
            int millisecondsSince = (int)(Time.deltaTime * 1000);
            SetTime(millisecondsSince);
        }
    }
}
