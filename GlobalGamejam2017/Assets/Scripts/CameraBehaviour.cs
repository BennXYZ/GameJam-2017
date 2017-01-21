using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    
	void FixedUpdate ()
    {
        float MouseX = Input.GetAxis("MouseX");
        float MouseY = Input.GetAxis("MouseY");
        
        Vector3 look = new Vector3(0, MouseX, 0);

        transform.Rotate(look);
    }
}
