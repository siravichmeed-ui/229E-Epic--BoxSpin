using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveDuration = 0.2f;
    public float jumpForce = 5f;

    private bool isMoving = false;
    private bool isGrounded = false;

    public UIManager uiManager;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        // 🔷 กลิ้ง
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W)) Move(Vector3.forward);
            if (Input.GetKeyDown(KeyCode.S)) Move(Vector3.back);
            if (Input.GetKeyDown(KeyCode.A)) Move(Vector3.left);
            if (Input.GetKeyDown(KeyCode.D)) Move(Vector3.right);
        }

        // 🔼 กระโดด
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // 💀 ตก = แพ้
        if (transform.position.y < -5f)
        {
            rb.linearVelocity = Vector3.zero;
            enabled = false;

            uiManager.ShowGameOverUI();
        }

        // 🔥 ยิง Ray ตอนกด E
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRay();
            Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        }

        
    }

    void Move(Vector3 dir)
    {
        isMoving = true;

        Vector3 pivot = transform.position + (dir / 2f) + Vector3.down / 2f;
        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        StartCoroutine(Rotate(pivot, axis));
    }

    IEnumerator Rotate(Vector3 pivot, Vector3 axis)
    {
        float rotated = 0f;
        float target = 90f;

        while (rotated < target)
        {
            float step = (90f / moveDuration) * Time.deltaTime;

            if (rotated + step > target)
                step = target - rotated;

            transform.RotateAround(pivot, axis, step);
            rotated += step;

            yield return null;
        }

        isMoving = false;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // 🔥 ฟังก์ชันยิง Ray
    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            Debug.Log("ยิงโดน: " + hit.collider.name);

            // 🎯 ตัวอย่าง: ยิงแล้วทำให้วัตถุเด้ง
            Rigidbody targetRb = hit.collider.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                targetRb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }

            // 💥 ตัวอย่าง: ยิงแล้วลบวัตถุ
            // Destroy(hit.collider.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("YOU WIN 🎉");

            rb.linearVelocity = Vector3.zero;
            enabled = false;

            // 🔥 เรียก UI แบบตรงๆ
            uiManager.ShowWinUI();
        }
    }

}