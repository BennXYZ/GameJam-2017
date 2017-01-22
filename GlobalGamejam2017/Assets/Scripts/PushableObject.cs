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

    List<GameObject> pushedBy;

    Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        pushedBy = new List<GameObject>();
    }

    public void FindSounds()
    {
        soundWave = GameObject.FindGameObjectWithTag("SoundWave");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pushedBy.Count; i++)
            if (pushedBy[i] == null)
                pushedBy.RemoveAt(i);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundWave" && !pushedBy.Contains(other.gameObject))
            Interact(other);
    }

    private void Interact(Collider other)
    {
        pushedBy.Add(other.gameObject);
        Transform forceTransformation = other.gameObject.transform;
        forceTransformation.LookAt(gameObject.transform.position);

        rigid.AddForce(forceTransformation.forward.normalized *  force * 5);
    }
}
