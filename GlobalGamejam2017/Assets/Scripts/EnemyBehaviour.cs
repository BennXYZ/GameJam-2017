<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float speed;

    [SerializeField]
    float distanceToPlayer;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private float iFrameCooldown;

    private float iFrames = 0;

    [SerializeField]
    AudioSource impulse;
	
	// Update is called once per frame
	void Update ()
    {
        if(playerTransform != null)
		if(Vector3.Distance(transform.position, playerTransform.position) > distanceToPlayer)
        {
            transform.LookAt(playerTransform);
            transform.Translate(-(transform.forward * speed));
        }
        if (iFrames > 0)
            iFrames -= Time.deltaTime;
        if (health <= 0)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundWave" && iFrames <= 0)
            Interact();
    }

    private void Interact()
    {
        health--;
        iFrames = iFrameCooldown;
    }
}
=======
﻿using System.Collections;
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
>>>>>>> master
