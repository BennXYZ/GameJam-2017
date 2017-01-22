using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightRange : MonoBehaviour {

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

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && isLighting == false && isUnLighting == false) isLighting = true;

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
        else if(isUnLighting)
        {
            if(unLightTime >= maxUnlightTime)
            {
                isUnLighting = false;
                unLightTime = 0;
            }

            pointLight.range = (maxUnlightTime / unLightTime);

            unLightTime += Time.deltaTime;
        }
    }
}
