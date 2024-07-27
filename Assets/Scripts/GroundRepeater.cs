using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRepeater : MonoBehaviour
{
    public GameObject groundPrefab;  // Prefab của nền
    public float groundLength = 20f;  // Chiều dài của nền
    private Transform playerTransform; // Đối tượng người chơi
    private Vector3 lastGroundEndPosition; // Vị trí cuối cùng của nền

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        lastGroundEndPosition = transform.position;
    }

    void Update()
    {
        if (playerTransform.position.x > lastGroundEndPosition.x - groundLength)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        Vector3 spawnPosition = lastGroundEndPosition + new Vector3(groundLength, 0, 0);
        Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        lastGroundEndPosition = spawnPosition;
    }
}
