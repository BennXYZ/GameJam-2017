using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float cameraSpeed;

    // Update is called once per frame
    void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(0, 0, vertical * movementSpeed);

        transform.Rotate(0, horizontal * cameraSpeed, 0);
	}
}
