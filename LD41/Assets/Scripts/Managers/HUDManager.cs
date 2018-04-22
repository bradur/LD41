// Date   : 22.04.2018 11:13
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public enum MenuType
{
    None,
    Start,
    Fail,
    Success,
    Death,
    TheEnd
}

public class HUDManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void SuccessMenu()
    {
        startMenu.SetActive(false);
        successMenu.SetActive(true);
        failMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    public void FailMenu()
    {
        startMenu.SetActive(false);
        successMenu.SetActive(false);
        failMenu.SetActive(true);
        deathMenu.SetActive(false);
    }

    public void StartMenu()
    {
        startMenu.SetActive(true);
        successMenu.SetActive(false);
        failMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    public void DeathMenu()
    {
        startMenu.SetActive(false);
        successMenu.SetActive(false);
        failMenu.SetActive(false);
        deathMenu.SetActive(true);
    }

    public void TheEndMenu()
    {
        startMenu.SetActive(false);
        successMenu.SetActive(false);
        failMenu.SetActive(false);
        deathMenu.SetActive(false);
        theEndMenu.SetActive(true);
    }

    public void ShowIconOnDriveHud(SpriteRenderer sr, Transform target)
    {
        hudCompass.ShowIcon(sr, target);
    }

    public void DestroyCompass()
    {
        hudCompass.DestroyIcons();
    }

    public void SetHealth(int health)
    {
        hudShootout.SetHealth(health);
    }

    [SerializeField]
    private HUDCompass hudCompass;

    [SerializeField]
    private HUDTimeLimit hudTimeLimit;

    [SerializeField]
    private HUDShootOut hudShootout;

    [SerializeField]
    private GameObject mainMenu;


    [SerializeField]
    private GameObject failMenu;

    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private GameObject successMenu;

    [SerializeField]
    private GameObject deathMenu;

    [SerializeField]
    private GameObject theEndMenu;

    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu(MenuType menuType)
    {
        mainMenu.SetActive(true);
        if (menuType == MenuType.Fail)
        {
            FailMenu();
        }
        else if (menuType == MenuType.Success)
        {
            SuccessMenu();
        }
        else if (menuType == MenuType.Start)
        {
            StartMenu();
        }
        else if (menuType == MenuType.Death)
        {
            DeathMenu();
        }
        else if (menuType == MenuType.TheEnd)
        {
            TheEndMenu();
        }
    }

    public void GetShot(int health)
    {
        hudShootout.GetShot(health);
    }

    public void PlayerShoot(int bulletsLeft)
    {
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
