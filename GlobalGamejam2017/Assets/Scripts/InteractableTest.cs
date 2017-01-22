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
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 80, 0));
    }
}
