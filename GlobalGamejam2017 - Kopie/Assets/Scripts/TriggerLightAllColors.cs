using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightAllColors : MonoBehaviour
{

    bool isLighting;
    bool isUnLighting;
    float lightTime = 0;
    float unLightTime = 0;

    List<GameObject> redObjects;
    List<GameObject> blueObjects;
    List<GameObject> greenObjects;

    [SerializeField]
    float maxLightImpulseTime;
    [SerializeField]
    float LightImpulseIntensity;
    [SerializeField]
    float maxUnlightTime;
    [SerializeField]
    Light pointLight;


    [SerializeField]
    AudioSource impulse;

    private void Start()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        for (var i = 0; i < objects.Length; i++)
        {
            if (objects[i].layer == 8) //Blue
            {
                blueObjects.Add(objects[i]);
            }
        }
        for (var i = 0; i < objects.Length; i++)
        {
            if (objects[i].layer == 9) //Red
            {
                redObjects.Add(objects[i]);
            }
        }
        for (var i = 0; i < objects.Length; i++)
        {
            if (objects[i].layer == 10) //Green
            {
                greenObjects.Add(objects[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Blue"))
        {
            pointLight.cullingMask = 256;
            pointLight.color = Color.blue;
            foreach(GameObject blueObject in blueObjects)
            {
                blueObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 255);
            }
            foreach (GameObject greenObject in greenObjects)
            {
                greenObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            foreach (GameObject redObject in redObjects)
            {
                redObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }

        }
        if (Input.GetButtonDown("Red"))
        {
            pointLight.cullingMask = 512;
            pointLight.color = Color.red;
        }
        if (Input.GetButtonDown("Green"))
        {
            pointLight.cullingMask = 1024;
            pointLight.color = Color.green;
        }

        if (Input.GetButtonDown("Fire1") && isLighting == false && isUnLighting == false)
        {
            isLighting = true;
            impulse.Play();
        }

        if (isLighting)
        {
            if (lightTime >= maxLightImpulseTime)
            {
                isLighting = false;
                isUnLighting = true;
                lightTime = 0;
            }


            pointLight.range += (lightTime * LightImpulseIntensity);


            lightTime += Time.deltaTime;
        }
        else if (isUnLighting)
        {
            if (unLightTime >= maxUnlightTime)
            {
                isUnLighting = false;
                unLightTime = 0;
            }

            pointLight.range -= (maxUnlightTime * unLightTime);

            unLightTime += Time.deltaTime;
        }
    }
}