using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab của chướng ngại vật
    public float spawnInterval = 1f; // Thay đổi thời gian để dễ kiểm tra
    private float timer;
    public float spawnOffsetX = 10f; // Khoảng cách giữa các chướng ngại vật
    public float spawnY = 0f; // Tọa độ Y cố định cho các chướng ngại vật
    public Transform player; // Tham chiếu đến nhân vật
    public float destroyOffsetX = 15f; // Khoảng cách để xóa chướng ngại vật sau khi nhân vật vượt qua
    public int maxObstacles = 10; // Giới hạn số lượng chướng ngại vật

    private Queue<GameObject> obstacleQueue = new Queue<GameObject>(); // Queue chướng ngại vật hiện tại

    private void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            if (obstacleQueue.Count < maxObstacles)
            {
                SpawnObstacle();
            }
            timer = 0f;
        }

        // Xóa chướng ngại vật đã vượt qua
        if (player != null)
        {
            while (obstacleQueue.Count > 0 && obstacleQueue.Peek().transform.position.x < player.position.x - destroyOffsetX)
            {
                Destroy(obstacleQueue.Dequeue());
            }
        }
    }

    void SpawnObstacle()
    {
        // Tạo vị trí chướng ngại vật với tọa độ Y cố định
        Vector3 spawnPosition = new Vector3(transform.position.x + spawnOffsetX, spawnY, 0);
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacleQueue.Enqueue(newObstacle); // Thêm chướng ngại vật vào queue
    }
}
