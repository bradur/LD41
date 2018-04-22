// Date   : 22.04.2018 13:29
// Project: LD41
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDShootOut : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    private Color cachedColor;

    private void Start()
    {
        cachedColor = imgComponent.color;
    }

    public void SetHealth(int health)
    {
        txtPlayerHealth.text = health.ToString();
    }

    public void GetShot(int health)
    {
        gettingShot = true;
        imgComponent.color = colorVariable;
        txtPlayerHealth.text = health.ToString();
    }

    public void UpdateBulletCount(int bullets)
    {
        txtComponent.text = bullets + "";
    }

    public void SetBulletCount(int bullets)
    {
        txtComponent.text = bullets + "";
    }

    [SerializeField]
    private Text txtPlayerHealth;

    private float shotEffectDuration = 0.2f;
    private float shotEffectTimer = 0f;
    private bool gettingShot = false;

    private void Update()
    {
        if (gettingShot)
        {
            shotEffectTimer += Time.deltaTime;
            if (shotEffectTimer > shotEffectDuration)
            {
                imgComponent.color = cachedColor;
                gettingShot = false;
                shotEffectTimer = 0f;
            }
         }
    }

}
