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

    List<Mesh> meshes;
    List<List<Vector3>> meshesVertices;
    List<Vector3> singleVertices;
    List<List<Color>> meshesColors;
    List<Color> singleColors;
    List<List<float>> meshesIntensities;
    List<float> singleIntensities;
    GameObject sphere;
    LightSignal sphereScript;
    List<GameObject> objects;

    // Use this for initialization
    void Start()
    {
        meshes = new List<Mesh>();
        singleVertices = new List<Vector3>();
        meshesVertices = new List<List<Vector3>>();
        singleColors = new List<Color>();
        meshesColors = new List<List<Color>>();
        singleIntensities = new List<float>();
        meshesIntensities = new List<List<float>>();
        objects = new List<GameObject>();



        for (int i = 0; i < GetComponentsInChildren<MeshFilter>().Length; i++)
        {
            meshes.Add(GetComponentsInChildren<MeshFilter>()[i].mesh);
            objects.Add(GetComponentsInChildren<MeshFilter>()[i].gameObject);
        }

        for (int m = 0; m < meshes.Count; m++)
        {
            singleColors = new List<Color>();
            singleVertices = new List<Vector3>();
            singleIntensities = new List<float>();
            for (int c = 0; c < meshes[m].vertices.Length; c++)
            {
                singleColors.Add(Color.black);
                singleVertices.Add(meshes[m].vertices[c]);
                singleIntensities.Add(0);
            }
            meshesColors.Add(singleColors);
            meshesIntensities.Add(singleIntensities);
            meshesVertices.Add(singleVertices);
        }



        sphere = GameObject.FindGameObjectWithTag(ReactingSphere.ToString());

        sphereScript = sphere.GetComponent<LightSignal>();

        for(int i = 0; i < meshes.Count; i++)
        meshes[i].colors = meshesColors[i].ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        //if (sphere.GetComponent<LightSignal>().GetStopIncreasing())
        //    Reset();
        CheckCollisionWithSphere();
        UpdateColors();
    }

    private void UpdateColors()
    {
        switch (ReactingSphere)
        {
            case SeeingSpheres.SeeEnvironmentSphere:
                for (int m = 0; m < meshesColors.Count; m++)
                    for (int c = 0; c < meshesColors[m].Count; c++)
                        if (meshesColors[m][c].b > 0)
                            meshesColors[m][c] = new Color(meshesColors[m][c].r, meshesColors[m][c].g, meshesColors[m][c].b - decreaseTime);
                        else
                            meshesColors[m][c] = new Color(meshesColors[m][c].r, meshesColors[m][c].g, 0);
                break;
            case SeeingSpheres.SeePuzzlesSphere:
                for (int m = 0; m < meshesColors.Count; m++)
                    for (int c = 0; c < meshesColors[m].Count; c++)
                        if (meshesColors[m][c].g > 0)
                            meshesColors[m][c] = new Color(meshesColors[m][c].r, meshesColors[m][c].g - decreaseTime, meshesColors[m][c].b);
                        else
                            meshesColors[m][c] = new Color(meshesColors[m][c].r, 0, meshesColors[m][c].b);
                break;
            case SeeingSpheres.SeeEnemiesSphere:
                for (int m = 0; m < meshesColors.Count; m++)
                    for (int c = 0; c < meshesColors[m].Count; c++)
                        if (meshesColors[m][c].r > 0)
                            meshesColors[m][c] = new Color(meshesColors[m][c].r - decreaseTime, meshesColors[m][c].g, meshesColors[m][c].b);
                        else
                            meshesColors[m][c] = new Color(0, meshesColors[m][c].g, meshesColors[m][c].b);
                break;
        }
        for (int m = 0; m < meshesColors.Count; m++)
                meshes[m].colors = meshesColors[m].ToArray();
    }

    private void CheckCollisionWithSphere()
    {
        for (int m = 0; m < meshes.Count; m++)
        {
            for(int v = 0; v < meshesVertices[m].Count; v++)
            if (sphereScript.Radius() > Vector3.Distance((objects[m].transform.rotation * (meshesVertices[m][v] * objects[m].transform.localScale.x) + objects[m].transform.position), sphere.transform.position) &&
                sphereScript.Radius() * sphereScript.sizeOfBorder < Vector3.Distance((objects[m].transform.rotation * (meshesVertices[m][v] * objects[m].transform.localScale.x) + objects[m].transform.position), sphere.transform.position)
                && (transform.rotation * meshesVertices[m][v] + transform.position).y > sphere.transform.position.y - sphereScript.maxDepth)
            {
                switch (ReactingSphere)
                {
                    case SeeingSpheres.SeeEnvironmentSphere:
                            meshesColors[m][v] = new Color(meshesColors[m][v].r, meshesColors[m][v].g, sphereScript.intensity);
                            break;
                    case SeeingSpheres.SeePuzzlesSphere:
                            meshesColors[m][v] = new Color(meshesColors[m][v].r, sphereScript.intensity, meshesColors[m][v].b);
                            break;
                    case SeeingSpheres.SeeEnemiesSphere:
                            meshesColors[m][v] = new Color(sphereScript.intensity, meshesColors[m][v].g, meshesColors[m][v].b);
                            break;
                }
            }
        }
    }
}
