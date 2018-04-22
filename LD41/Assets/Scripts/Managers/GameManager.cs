// Date   : 22.04.2018 10:17
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public void GetShot()
    {
        hudManager.GetShot();
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
        vehicleMovement.DisableDriving(stopCar);
        cameraManager.SwitchToCarSeatView();
        miniMap.SetActive(false);
        aimHUD.SetActive(true);
        hudManager.SetBulletCount(bullets);
        mouseLook.enabled = true;
        musicManager.SwitchToState(MusicState.Shooting);
        SoundManager.main.PlaySound(SoundType.Car);
    }

    public void SwitchToTopDown()
    {
        musicManager.SwitchToState(MusicState.Driving);
        driveHUD.SetActive(true);
        vehicleMovement.EnableDriving();
        cameraManager.SwitchToTopDown();
        miniMap.SetActive(true);
        aimHUD.SetActive(false);
        mouseLook.enabled = false;
        SoundManager.main.PlaySound(SoundType.Car);
    }

    public void SetTimeLimit(int timeLimit)
    {
        hudManager.SetTimeLimit(timeLimit);
    }

    public void PlacePlayer(Transform target)
    {
        player.transform.position = target.position;
    }

    public void TimeLimitReached()
    {
        Debug.Log("Timelimit!");
    }

    public void EndLevel()
    {
        Time.timeScale = 0f;
        musicManager.PlayMenuMusic();
        hudManager.ShowMainMenu();
        Cursor.lockState = CursorLockMode.None;
        SoundManager.main.StopSound(SoundType.Car);
    }

    [SerializeField]
    private int levelNumber = 0;

    private Level currentLevel;

    public void NextLevel()
    {
        hudManager.DestroyCompass();
        musicManager.PlayMusic(MusicState.Driving);
        hudManager.HideMainMenu();
        if (!startingLevel)
        {
            if (levelNumber <= levels.Count)
            {
                Time.timeScale = 0f;
                currentLevel = levels[levelNumber];
                driveHUD.SetActive(true);
                currentLevel.gameObject.SetActive(true);
                miniMap.SetActive(true);
                levelNumber += 1;
                startingLevel = true;
                SoundManager.main.PlaySound(SoundType.Car);
                currentLevel.Initialize();
            }
            else
            {
                Debug.Log("The end!");
            }
        }
        else
        {
            Debug.Log("Already starting!");
        }

    }

    public void StartLevel()
    {
        Time.timeScale = 1f;
        bullets = currentLevel.Bullets;
        startingLevel = false;
    }

    void Start()
    {
        Time.timeScale = 0f;
        hudManager.ShowMainMenu();
    }

    [SerializeField]
    private float startingLevelDelay = 2f;

    private float startingLevelTimer = 0f;
    private bool startingLevel = false;

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
    }
}
