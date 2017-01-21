using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBehaviour : MonoBehaviour {
    
    Transform playerTransform;

    [SerializeField]
    float speed;
    [SerializeField]
    float distanceToPlayer;


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    
	void Update ()
    {
        transform.LookAt(playerTransform);
    }
}
