using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject: MonoBehaviour
{

    GameObject soundWave;

    [SerializeField]
    [Range(0.001f,200)]
    private float weight = 1;

    // Use this for initialization
    void Start()
    {
        //FindSounds();
    }

    public void FindSounds()
    {
        soundWave = GameObject.FindGameObjectWithTag("SoundWave");
    }

    // Update is called once per frame
    void Update()
    {
            //if (soundWave == null)
            //    FindSounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SoundWave")
            Interact(collision);
    }

    private void Interact(Collision collision)
    {
        Debug.Log("lol");
        Transform forceTransformation = collision.transform;
        forceTransformation.LookAt(gameObject.transform.position);

        GetComponent<Rigidbody>().AddForce(forceTransformation.forward.normalized * (1 / weight));
    }
}
