using UnityEngine;

public class RaySwitch : MonoBehaviour
{
    public bool isActivated = false;

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            Debug.Log(name + " Activated!");

            // เปลี่ยนสีให้รู้ว่าเปิดแล้ว
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}