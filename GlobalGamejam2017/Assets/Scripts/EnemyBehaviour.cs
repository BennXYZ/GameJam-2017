using System.Collections;
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
    AudioSource impulse;
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(transform.position, playerTransform.position) > distanceToPlayer)
        {
            transform.LookAt(playerTransform);
            transform.Translate(-(transform.forward * speed));
        }
	}
}
