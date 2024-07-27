using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public GameObject backgroundPrefab;  // Prefab của background
    public float backgroundLength = 20f;  // Chiều dài của background
    private Transform playerTransform; // Đối tượng người chơi
    private Vector3 lastBackgroundEndPosition; // Vị trí cuối cùng của background
    public bool isGameOver = false;  // Biến trạng thái trò chơi

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        lastBackgroundEndPosition = transform.position;
        // Khởi tạo background đầu tiên
        Instantiate(backgroundPrefab, lastBackgroundEndPosition, Quaternion.identity);
    }

    void Update()
    {
        if (isGameOver) return; // Dừng kéo dài background khi trò chơi kết thúc

        if (playerTransform.position.x > lastBackgroundEndPosition.x - backgroundLength)
        {
            SpawnBackground();
        }
    }

    void SpawnBackground()
    {
        Vector3 spawnPosition = lastBackgroundEndPosition + new Vector3(backgroundLength, 0, 10);
        Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        lastBackgroundEndPosition = spawnPosition;
    }
}
