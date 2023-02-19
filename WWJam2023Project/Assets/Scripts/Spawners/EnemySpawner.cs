using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Nonsense")]
    public GameObject EnemyPrefab;
    public float delayTime = 20.0f;
    public float intervalTime = 10.0f;

    [Header("Other Nonsense")]
    public Transform Area1MinX;
    public Transform Area1MaxX;
    public Transform Area1MinY;
    public Transform Area1MaxY;
    public Transform Area2MinX;
    public Transform Area2MaxX;
    public Transform Area2MinY;
    public Transform Area2MaxY;
    public Transform Area3MinX;
    public Transform Area3MaxX;
    public Transform Area3MinY;
    public Transform Area3MaxY;
    public Transform Area4MinX;
    public Transform Area4MaxX;
    public Transform Area4MinY;
    public Transform Area4MaxY;

    public void OnGameStart()
    {
        InvokeRepeating("SpawnEnemy", delayTime, intervalTime);
    }

    public void SpawnEnemy()
    {
        int areaIndex = Random.Range(0, 4);
        Vector2 spawnPos = GetSpawnPos(areaIndex);
        Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
    }

    public Vector2 GetSpawnPos(int areaIndex)
    {
        Vector2 spawnPos;
        switch (areaIndex)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(Area1MinX.position.x, Area1MaxX.position.x),
                    Random.Range(Area1MinY.position.y, Area1MaxY.position.y));
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(Area2MinX.position.x, Area2MaxX.position.x),
                    Random.Range(Area2MinY.position.y, Area2MaxY.position.y));
                break;
            case 2:
                spawnPos = new Vector2(Random.Range(Area3MinX.position.x, Area3MaxX.position.x),
                    Random.Range(Area3MinY.position.y, Area3MaxY.position.y));
                break;
            case 3:
                spawnPos = new Vector2(Random.Range(Area4MinX.position.x, Area4MaxX.position.x),
                    Random.Range(Area4MinY.position.y, Area4MaxY.position.y));
                break;
            default:
                spawnPos = new Vector2(Random.Range(Area1MinX.position.x, Area1MaxX.position.x),
                    Random.Range(Area1MinY.position.y, Area1MaxY.position.y));
                break;
        }
        return spawnPos;
    }
}
