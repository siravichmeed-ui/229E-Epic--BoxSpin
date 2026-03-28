using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Player
    public Vector3 offset;       // ระยะห่าง
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // ทำให้ลื่น
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;

        // มองไปที่ Player
        transform.LookAt(target);
    }
}   