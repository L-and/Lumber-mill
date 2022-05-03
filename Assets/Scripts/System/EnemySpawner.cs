using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 적 프리팹 리스트
    Vector3 spawnPoint; // 적 생성 위치

    private void Awake()
    {
        Vector3 spawnPoint = transform.position; // 적생성위치 지정
    }

    public void EnemySpawn() // 적생성
    {
        print("적 생성!");
        Instantiate(enemyPrefabs[0], transform); // 적프리팹 생성
    }
}
