using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform player;


    void Update()
    {
        transform.position = player.position;

        MouseAiming();
    }

    [SerializeField]
    private float turnSpeed;

    void MouseAiming()
    {
        Vector3 rot = new Vector3(0f, 0f, 0f);
        //Left/Right
        if (Input.GetAxis("Mouse X") < 0)
        {
            rot.y -= 1;
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            rot.y += 1;
        }

        //Up/Dowm
        if (Input.GetAxis("Mouse Y") < 0)
        {
            rot.x += 1;
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            rot.x -= 1;
        }

        transform.Rotate(rot.x * turnSpeed, rot.y * turnSpeed, 0);
        
    }
}
