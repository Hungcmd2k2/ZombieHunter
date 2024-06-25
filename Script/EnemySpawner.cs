using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 3f;
    public Transform[] spawnPoints;
    public int Number_Enemy;
    public int count = 0;
    public int gameLevel = 10;
    public int count_Level = 1;
    private float nextSpawnTime;
    public Player player;
    public int Enemy_Die;
    public TMP_Text text;
    public GameObject UI_WIN;
    public GameObject Character;
    public ManagerItem ManagerItem;
    void Start()
    {
        text.SetText("Level:" + count_Level.ToString());
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
        Enemy_Die = player.Kill_Enemy;
        if (Enemy_Die == Number_Enemy)
        {
            if (count_Level < gameLevel)
            {
                Number_Enemy = Number_Enemy + 3;
                count = 0;
                player.Kill_Enemy = 0;
                count_Level += 1;
                text.SetText("Level: " + count_Level.ToString());
                DeleteItemHP();
            }
            else
            {
                Invoke("showUI", 4f);
            }

        }
    }
    public void DeleteItemHP()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Item_HP");
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
        ManagerItem.countHp = 0;
    }
    public void showUI()
    {
        UI_WIN.SetActive(true);
        Time.timeScale = 0;
        Destroy(Character);
    }
    void SpawnEnemy()
    {
        if (count < Number_Enemy)
        {
            // Chọn ngẫu nhiên một điểm sinh ra từ mảng spawnPoints
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            // Sinh ra một đối tượng Enemy tại spawnPoint
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            count++;

        }

    }

}
