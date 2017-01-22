using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBehaviour : MonoBehaviour {

    private Transform playerTransform;

	void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();	
	}
	
	void Update ()
    {
        transform.LookAt(playerTransform);
	}
}
