using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightAllColors : MonoBehaviour
{

    bool isLighting;
    bool isUnLighting;
    float lightTime = 0;
    float unLightTime = 0;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Blue"))
        {
            pointLight.cullingMask = 256;
            pointLight.color = Color.blue;
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


            pointLight.range = 1 + (lightTime * LightImpulseIntensity);


            lightTime += Time.deltaTime;
        }
        else if (isUnLighting)
        {
            if (unLightTime >= maxUnlightTime)
            {
                isUnLighting = false;
                unLightTime = 0;
            }

            pointLight.range = (maxUnlightTime / unLightTime);

            unLightTime += Time.deltaTime;
        }
    }
}