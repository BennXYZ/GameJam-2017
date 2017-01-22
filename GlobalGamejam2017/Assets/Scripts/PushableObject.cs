using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject: MonoBehaviour
{

    GameObject soundWave;

    [SerializeField]
    [Range(0.001f,200)]
    private float force = 1;

    Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
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
        if (other.gameObject.tag == "SoundWave" && rigid.velocity == Vector3.zero)
            Interact(other);
    }

    private void Interact(Collider other)
    {
        Debug.Log("lol");
        Transform forceTransformation = other.gameObject.transform;
        forceTransformation.LookAt(gameObject.transform.position);

        rigid.AddForce(forceTransformation.forward.normalized *  force * 5);
    }
}
