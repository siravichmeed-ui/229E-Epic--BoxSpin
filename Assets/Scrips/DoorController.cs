using UnityEngine;

public class DoorController : MonoBehaviour
{
    public RaySwitch[] switches;
    public Vector3 openOffset = new Vector3(0, 3, 0);
    public float speed = 2f;

    private bool isOpen = false;
    private Vector3 closedPos;
    private Vector3 openPos;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
    }

    void Update()
    {
        if (!isOpen && CheckAllSwitches())
        {
            isOpen = true;
        }

        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPos, Time.deltaTime * speed);
        }
    }

    bool CheckAllSwitches()
    {
        foreach (var s in switches)
        {
            if (!s.isActivated)
                return false;
        }
        return true;
    }
}