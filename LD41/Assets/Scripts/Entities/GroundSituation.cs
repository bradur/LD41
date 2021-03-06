// Date   : 22.04.2018 08:45
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundSituation : MonoBehaviour
{

    [SerializeField]
    private List<Enemy> enemies;

    [SerializeField]
    private float enemySpawnInterval = 2f;
    private float enemySpawnTimer = 0f;

    [SerializeField]
    private float startSituationDelay = 3f;
    private float startSituationTimer = 0f;

    private List<Enemy> activeEnemies = new List<Enemy>();
    private bool situationActive = false;

    private bool situationStarting = false;

    private bool spent = false;

    private Transform playerCamera;

    [SerializeField]
    private MeshRenderer mesh;

    [SerializeField]
    private bool isEnd = false;
    public bool LevelEnd { get { return isEnd; } }

    [SerializeField]
    private bool isBank = false;

    void Start()
    {

    }

    public void StartSituation(Transform playerCamera)
    {
        if (!spent)
        {
            if (isEnd)
            {
                GameManager.main.EndLevel();
            }
            else
            {
                spent = true;
                mesh.enabled = false;
                this.playerCamera = playerCamera;
                situationStarting = true;
            }
        }
    }

    public void EnemyDie(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        if (activeEnemies.Count == 0 && enemies.Count == 0)
        {
            EndSituation();
        }
    }

    public void EndSituation()
    {
        GameManager.main.SwitchToTopDown(isBank);
    }

    void Update()
    {
        if (situationStarting)
        {
            startSituationTimer += Time.deltaTime;
            if (startSituationTimer > startSituationDelay)
            {
                situationStarting = false;
                situationActive = true;
            }
        }
        if (situationActive)
        {
            enemySpawnTimer += Time.deltaTime;
            if (enemySpawnTimer > enemySpawnInterval)
            {
                enemySpawnTimer = 0f;
                if (enemies.Count > 0)
                {
                    Enemy enemy = enemies[Random.Range(0, enemies.Count)];
                    enemy.gameObject.SetActive(true);
                    enemies.Remove(enemy);
                    enemy.Initialize(playerCamera, this);
                    activeEnemies.Add(enemy);
                }
                else
                {
                    situationActive = false;
                }
            }
        }
    }
}
