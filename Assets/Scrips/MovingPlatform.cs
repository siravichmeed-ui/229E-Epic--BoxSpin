    using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float distance = 3f;   // ระยะที่วิ่งไปซ้าย/ขวา
    public float speed = 2f;      // ความเร็ว

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = Mathf.PingPong(Time.time * speed, distance * 2) - distance;

        transform.position = new Vector3(
            startPos.x,
            startPos.y,
            startPos.z + move
        );
    }
}