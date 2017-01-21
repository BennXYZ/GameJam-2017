using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseColour : MonoBehaviour
{

    enum SeeingSpheres { SeeEnvironmentSphere, SeeEnemiesSphere, SeePuzzlesSphere}

    [SerializeField]
    private SeeingSpheres ReactingSphere = SeeingSpheres.SeeEnvironmentSphere;

    [SerializeField]
    [Range(0.001f,1)]
    private float decreaseTime = 0.1f;

    Mesh mesh;
    Vector3[] vertices;
    Color[] colors;
    float[] intensities;
    List<int> triggeredVerticies;
    private bool atSphereRange;
    SphereCollider seeingSphere;
    GameObject sphere;
    LightSignal sphereScript;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        sphere = GameObject.FindGameObjectWithTag(ReactingSphere.ToString());
        seeingSphere = sphere.GetComponent<SphereCollider>();
        sphereScript = sphere.GetComponent<LightSignal>();

        colors = new Color[vertices.Length];
        intensities = new float[vertices.Length];
        triggeredVerticies = new List<int>();

        for (int i = 0; i < colors.Length; i++)
            colors[i] = Color.black;

        mesh.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        //if (sphere.GetComponent<LightSignal>().GetStopIncreasing())
        //    Reset();
        CheckCollisionWithSphere();
        UpdateColors();
    }

    private void Reset()
    {
        triggeredVerticies.Clear();
    }

    private void UpdateColors()
    {
        switch (ReactingSphere)
        {
            case SeeingSpheres.SeeEnvironmentSphere:
                for (int i = 0; i < colors.Length; i++)
                    if (colors[i].g > 0)
                        colors[i].g -= decreaseTime;
                    else
                        colors[i].g = 0;
                break;
            case SeeingSpheres.SeePuzzlesSphere:
                for (int i = 0; i < colors.Length; i++)
                    if (colors[i].b > 0)
                        colors[i].b -= decreaseTime;
                    else
                        colors[i].b = 0;
                break;
            case SeeingSpheres.SeeEnemiesSphere:
                for (int i = 0; i < colors.Length; i++)
                    if (colors[i].r > 0)
                        colors[i].r -= decreaseTime;
                    else
                        colors[i].r = 0;
                break;
        }


        mesh.colors = colors;
    }

    private void CheckCollisionWithSphere()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            if (seeingSphere.transform.localScale.x > Vector3.Distance((transform.rotation * vertices[i] + transform.position), seeingSphere.transform.position) &&
                seeingSphere.transform.localScale.x * sphereScript.sizeOfBorder < Vector3.Distance((transform.rotation * vertices[i] + transform.position), seeingSphere.transform.position)
                && (transform.rotation * vertices[i] + transform.position).y > sphere.transform.position.y - sphereScript.maxDepth)
            {
                switch (ReactingSphere)
                {
                    case SeeingSpheres.SeeEnvironmentSphere:
                        colors[i].g = sphereScript.intensity;
                        break;
                    case SeeingSpheres.SeePuzzlesSphere:
                        colors[i].b = sphereScript.intensity;
                        break;
                    case SeeingSpheres.SeeEnemiesSphere:
                        colors[i].r = sphereScript.intensity;
                        break;
                }
            }
        }
    }
}
