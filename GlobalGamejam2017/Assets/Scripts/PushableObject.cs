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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundWave")
            Interact(other);
    }

    private void Interact(Collider other)
    {
        Debug.Log("lol");
        Transform forceTransformation = other.gameObject.transform;
        forceTransformation.LookAt(gameObject.transform.position);

        GetComponent<Rigidbody>().AddForce(forceTransformation.forward.normalized * (2000 / weight));
    }
}
