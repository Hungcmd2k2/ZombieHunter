using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerItem : MonoBehaviour
{
    public GameObject ItemHPPrefabs;
    public float spawnInterval = 3f; 
    private float nextSpawnTime;
    public Transform[] HP_Points;
    public int Number_ItemHp;
    public int countHp =0;
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnItemHp();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    void SpawnItemHp()
    {
        if (countHp < Number_ItemHp)
        {
            Transform spawnPoint = HP_Points[Random.Range(0, HP_Points.Length)];
            Instantiate(ItemHPPrefabs, spawnPoint.position, Quaternion.identity);
            countHp++;
        }
    }
}
