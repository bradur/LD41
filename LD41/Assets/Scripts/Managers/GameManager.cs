// Date   : 22.04.2018 10:17
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager main;

    [SerializeField]
    private SimpleSmoothMouseLook mouseLook;


    [SerializeField]
    private VehicleMovement vehicleMovement;

    [SerializeField]
    private GameObject aimHUD;

    [SerializeField]
    private GameObject miniMap;

    [SerializeField]
    private GameObject driveHUD;

    [SerializeField]
    private CameraManager cameraManager;

    [SerializeField]
    private HUDManager hudManager;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        main = this;
    }

    public Transform GetPlayerTransform()
    {
        return player.transform;
    }

    [SerializeField]
    private MusicManager musicManager;

    [SerializeField]
    private List<Level> levels;

    public void ShowBanks(int banksToRob)
    {
        hudManager.ShowBanks(banksRobbed, banksToRob);
    }

    private int hp = 5;
    public void GetShot()
    {
        hp -= 1;
        if (hp <= 0)
        {
            hp = 0;
            mouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            hudManager.ShowMainMenu(MenuType.Death);
            Time.timeScale = 0f;
        }
        hudManager.GetShot(hp);
    }

    public void ShowIconOnDriveHud(SpriteRenderer sr, Transform target)
    {
        hudManager.ShowIconOnDriveHud(sr, target);
    }

    private int bullets;
    public bool PlayerShoot()
    {
        if (bullets > 0)
        {
            bullets -= 1;
            hudManager.PlayerShoot(bullets);
            return true;
        }
        return false;
    }

    public void SwitchToCarSeatView(bool stopCar)
    {
        driveHUD.SetActive(false);
        vehicleMovement.DisableDriving(true);
        cameraManager.SwitchToCarSeatView();
        miniMap.SetActive(false);
        aimHUD.SetActive(true);
        hudManager.SetBulletCount(bullets);
        mouseLook.enabled = true;
        musicManager.SwitchToState(MusicState.Shooting);
        SoundManager.main.PlaySound(SoundType.Car);
    }

    [SerializeField]
    private GameObject topDownCam;

    public void SwitchToTopDown(bool bankWasRobbed)
    {
        if (bankWasRobbed)
        {
            banksRobbed += 1;
            ShowBanks(currentLevel.RequiredBanks);
        }
        musicManager.SwitchToState(MusicState.Driving);
        driveHUD.SetActive(true);
        vehicleMovement.EnableDriving(bankWasRobbed);
        cameraManager.SwitchToTopDown();
        miniMap.SetActive(true);
        aimHUD.SetActive(false);
        mouseLook.enabled = false;
        SoundManager.main.PlaySound(SoundType.Car);
    }


    [SerializeField]
    private DirtTrailManager dirtTrailManager;

    public void SetTimeLimit(int timeLimit)
    {
        hudManager.SetTimeLimit(timeLimit);
    }

    public void PlacePlayer(Transform target)
    {
        player.transform.position = target.position;
        player.transform.rotation = target.rotation;
    }

    public void TimeLimitReached()
    {
        vehicleMovement.DisableDriving(true);
        hudManager.ShowMainMenu(MenuType.Fail);
        Cursor.lockState = CursorLockMode.None;
        SoundManager.main.StopSound(SoundType.Car);
        Time.timeScale = 0f;
        Debug.Log("Timelimit!");
    }

    private int banksRobbed = 0;

    public void EndLevel()
    {
        if (banksRobbed >= currentLevel.RequiredBanks)
        {
            Time.timeScale = 0f;
            musicManager.PlayMenuMusic();
            hudManager.ShowMainMenu(MenuType.Success);
            Cursor.lockState = CursorLockMode.None;
            SoundManager.main.StopSound(SoundType.Car);
        } else
        {
            hudManager.ShowMessage("You need to rob " + currentLevel.RequiredBanks + " to get to the next level!");
        }

    }

    [SerializeField]
    private int levelNumber = 0;

    private Level currentLevel;
    private int currentLevelNumber = 0;

    public void LoadLevel()
    {
        banksRobbed = 0;
        hp = 5;
        hudManager.SetHealth(hp);
        vehicleMovement.StopMovement();
        dirtTrailManager.ClearAllTrails();
        hudManager.HideMainMenu();
        hudManager.DestroyCompass();
        musicManager.PlayMusic(MusicState.Driving);
        Time.timeScale = 0f;
        for (int i = 0; levels.Count > i; i += 1)
        {
            levels[i].gameObject.SetActive(false);
        }
        currentLevel = levels[levelNumber];
        currentLevelNumber = levelNumber;
        ShowBanks(currentLevel.RequiredBanks);
        driveHUD.SetActive(true);
        currentLevel.gameObject.SetActive(true);
        miniMap.SetActive(true);
        startingLevel = true;
        SoundManager.main.PlaySound(SoundType.Car);
        currentLevel.Initialize();
        topDownCam.SetActive(true);
        Vector3 newPosition = vehicleMovement.transform.position;
        newPosition.y = topDownCam.transform.position.y;
        topDownCam.transform.position = newPosition;
    }

    public void NextLevel()
    {
        if (!startingLevel)
        {
            if (levelNumber < levels.Count)
            {
                LoadLevel();
                levelNumber += 1;
            }
            else
            {
                hudManager.ShowMainMenu(MenuType.TheEnd);
                Debug.Log("The end!");
            }
        }
        else
        {
            Debug.Log("Already starting!");
        }

    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("RestartLevel");
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetInt("RestartLevel", currentLevelNumber);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        Time.timeScale = 1f;
        bullets = currentLevel.Bullets;
        startingLevel = false;
    }

    void Start()
    {
        int restartedLevel = PlayerPrefs.GetInt("RestartLevel", -1);
        if (restartedLevel != -1)
        {
            Time.timeScale = 1f;
            levelNumber = restartedLevel;
            PlayerPrefs.DeleteKey("RestartLevel");
            hudManager.HideMainMenu();
            NextLevel();
        }
        else
        {
            hudManager.ShowMainMenu(MenuType.Start);
            Time.timeScale = 0f;
        }

    }

    [SerializeField]
    private float startingLevelDelay = 2f;

    private float startingLevelTimer = 0f;
    private bool startingLevel = false;

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        mayPause = true;
        hudManager.HideMainMenu();
    }

    private bool mayPause = true;

    void Update()
    {
        if (startingLevel)
        {
            startingLevelTimer += Time.unscaledDeltaTime;
            if (startingLevelTimer >= startingLevelDelay)
            {
                startingLevel = false;
                StartLevel();
            }
        }
        if (KeyManager.main.GetKeyUp(GameAction.OpenMenu))
        {
            mayPause = false;
            Time.timeScale = 0f;
            hudManager.ShowMainMenu(MenuType.Pause);
        }
    }
}
