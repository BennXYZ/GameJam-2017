using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    private float cameraOffset;
    [SerializeField]
    private List<GameObject> players = new List<GameObject>();

	
	void FixedUpdate ()
    {
        //transform.position = players[0].transform.position;
        //transform.rotation = players[0].transform.rotation;
        //transform.Translate(transform.forward * cameraOffset);

        if (players.Count == 1)
        {
            transform.position = players[0].transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 1);
            transform.LookAt(players[0].transform);
        }
        else if (players.Count == 2)
        {

        }
        else if (players.Count == 3)
        {

        }
    }
}
