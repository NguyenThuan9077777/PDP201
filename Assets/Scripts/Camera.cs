using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Tham chiếu đến nhân vật
    public Vector3 offset; // Khoảng cách giữa camera và nhân vật

    void Start()
    {
        // Đảm bảo camera bắt đầu ở vị trí đúng
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Cập nhật vị trí của camera dựa trên vị trí của nhân vật và offset
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        }
    }

}
