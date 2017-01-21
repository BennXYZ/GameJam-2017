using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundSignal: MonoBehaviour {

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
    private UnityEvent Create;

    private bool stopIncreasing = false;

    // Use this for initialization
    void Start()
    {
        Reset();
        Create.Invoke();
    }

    public float Radius()
    {
        return radius;
    }

    public bool GetStopIncreasing()
    {
        return stopIncreasing;
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
        {
            Destroy(gameObject);
        }

	}

    private void UpdateGrow()
    {
        intensity -= lossPerOverTime;
        transform.localScale = new Vector3(transform.localScale.x + growPerOverTime * intensity * intensity,
            transform.localScale.y + growPerOverTime * intensity * intensity,
            transform.localScale.z + growPerOverTime * intensity * intensity);
    }
}
