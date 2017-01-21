using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightsignal : MonoBehaviour {

    GameObject seeingEnvironmentSphere;
    GameObject seeingEnemiesSphere;
    GameObject seeingPuzzlesSphere;

    LightSignal seeingEnvironmentSphereScript;
    LightSignal seeingEnemiesSphereScript;
    LightSignal seeingPuzzlesSphereScript;

    // Use this for initialization
    void Start () {
        seeingEnvironmentSphere = GameObject.FindGameObjectWithTag("SeeEnvironmentSphere");
        seeingEnemiesSphere = GameObject.FindGameObjectWithTag("SeeEnemiesSphere");
        seeingPuzzlesSphere = GameObject.FindGameObjectWithTag("SeePuzzlesSphere");

        seeingEnvironmentSphereScript = seeingEnvironmentSphere.GetComponent<LightSignal>();
        seeingEnemiesSphereScript = seeingEnemiesSphere.GetComponent<LightSignal>();
        seeingPuzzlesSphereScript = seeingPuzzlesSphere.GetComponent<LightSignal>();


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            seeingEnvironmentSphere.transform.position = gameObject.transform.position;
            seeingEnvironmentSphereScript.Reset();
        }

        

        
	}
}
