using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{

    GameObject soundWave;

    // Use this for initialization
    void Start()
    {
        FindSounds();
    }

    public void FindSounds()
    {
        soundWave = GameObject.FindGameObjectWithTag("SoundWave");
    }

    // Update is called once per frame
    void Update()
    {
            if (soundWave == null)
                FindSounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == soundWave.GetComponent<Rigidbody>())
            Interact();
    }

    private void Interact()
    {
        Debug.Log("lol");
    }
}
