using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSignal : MonoBehaviour {

    [SerializeField]
    [Range(0.01f,1)]
    private float startIntensity = 1;

    [SerializeField]
    [Range(0.0001f, 0.1f)]
    private float lossPerOverTime = 0.01f;

    [SerializeField]
    [Range(0.0001f, 0.1f)]
    private float growPerOverTime = 0.01f;

    [SerializeField]
    [Range(0, 200)]
    public float maxDepth = 0;

    [SerializeField]
    [Range(0, 1)]
    public float sizeOfBorder = 0;
    private float radius = 0;

    private float startSize;
    public float intensity;

    [SerializeField]
    private UnityEvent interact;

    private bool stopIncreasing = false;

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    public Vector4 Information()
    {
        return new Vector4(transform.position.x, transform.position.y, transform.position.z, radius);
    }

    public bool GetStopIncreasing()
    {
        return stopIncreasing;
    }

    private void OnCollisionEnter(Collision collision)
    {
        interact.Invoke();
    }

    public void Reset()
    {
        stopIncreasing = false;
        radius = 0;
        intensity = startIntensity;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            Reset();
        if (!stopIncreasing)
            UpdateGrow();
        if (intensity <= 0)
            stopIncreasing = true;
	}

    private void UpdateGrow()
    {
        intensity -= lossPerOverTime;
        radius += growPerOverTime;
    }
}
