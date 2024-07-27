using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
   
    public float timeBeforeSpeedUp = 5f; // Thời gian trước khi tăng tốc (5 giây)
    public float newTimeScale = 0.6f; // Tốc độ mới của game (tăng gấp đôi)
    private PlayerController playerController;
    private void Start()
    {
        // Lên lịch tăng tốc độ sau thời gian chỉ định
        Invoke("IncreaseGameSpeed", timeBeforeSpeedUp);
    }

    void IncreaseGameSpeed()
    {
        Time.timeScale = newTimeScale; // Thay đổi tốc độ game
        Debug.Log("Game speed increased!");

    }
}


