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
    private HUDShootOut hudShootout;

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

    public void GetShot()
    {
        hudShootout.GetShot();
    }

    public void PlayerShoot(int bulletsLeft) {
        hudShootout.UpdateBulletCount(bulletsLeft);
    }

    public void SetBulletCount(int bulletCount)
    {
        hudShootout.SetBulletCount(bulletCount);
    }

    public void SetTimeLimit(int timeLimit)
    {
        hudTimeLimit.gameObject.SetActive(true);
        hudTimeLimit.Initialize(timeLimit);
    }
}
