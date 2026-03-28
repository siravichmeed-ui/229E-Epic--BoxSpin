using UnityEngine;

public class Rock : MonoBehaviour
{
    public float bounceForce = 10f;   // ความแรงเด้ง

    void Start()
    {
        // 🧹 ลบตัวเองหลัง 2 วิ
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // 💥 เด้งขึ้นเล็กน้อย
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}