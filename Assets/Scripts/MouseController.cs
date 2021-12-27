using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject RotateGo;
   
    [SerializeField] private FixedJoystick joystickRotate;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.freezeRotation = true;
        }
    }
    void Update()
    {
        float sensHor;
        sensHor = 0f;
        if (joystickRotate.Direction.x < 0f)
        {
            sensHor = -1f;
        }
        else if (joystickRotate.Direction.x > 0f)
        {
            sensHor = 1f;
        }
        

        RotateGo.transform.Rotate(0, sensHor, 0);
    }
}
