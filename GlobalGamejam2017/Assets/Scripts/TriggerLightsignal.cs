using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;


public class TriggerLightsignal : MonoBehaviour {

    GameObject seeingEnvironmentSphere;
    GameObject seeingEnemiesSphere;
    GameObject seeingPuzzlesSphere;

    LightSignal seeingEnvironmentSphereScript;
    LightSignal seeingEnemiesSphereScript;
    LightSignal seeingPuzzlesSphereScript;

    [SerializeField]
    private float BlueLightCooldown = 1;
    private float BlueLightTimer;

    [SerializeField]
    private float RedLightCooldown = 1;
    private float RedLightTimer;

    [SerializeField]
    private float GreenLightCooldown = 1;
    private float GreenLightTimer;

    AudioSource[] PlayerSounds;

    // Use this for initialization
    void Start () {
        seeingEnvironmentSphere = GameObject.FindGameObjectWithTag("SeeEnvironmentSphere");
        seeingEnemiesSphere = GameObject.FindGameObjectWithTag("SeeEnemiesSphere");
        seeingPuzzlesSphere = GameObject.FindGameObjectWithTag("SeePuzzlesSphere");

        PlayerSounds = gameObject.GetComponents<AudioSource>();
        BlueLightTimer = BlueLightCooldown;

        seeingEnvironmentSphereScript = seeingEnvironmentSphere.GetComponent<LightSignal>();
        seeingEnemiesSphereScript = seeingEnemiesSphere.GetComponent<LightSignal>();
        seeingPuzzlesSphereScript = seeingPuzzlesSphere.GetComponent<LightSignal>();


    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimers();
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed && BlueLightTimer <= 0)
        {

            PlayerSounds[0].Play();
            BlueLightTimer = BlueLightCooldown;
            seeingEnvironmentSphere.transform.position = gameObject.transform.position;
            seeingEnvironmentSphereScript.Reset();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && GreenLightTimer <= 0)
        {
            PlayerSounds[0].Play();
            GreenLightTimer = GreenLightCooldown;
            seeingPuzzlesSphere.transform.position = gameObject.transform.position;
            seeingPuzzlesSphereScript.Reset();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && RedLightTimer <= 0)
        {
            PlayerSounds[0].Play();
            RedLightTimer = RedLightCooldown;
            seeingEnemiesSphereScript.transform.position = gameObject.transform.position;
            seeingEnemiesSphereScript.Reset();
        }


    }

    void UpdateTimers()
    {
        if (BlueLightTimer > 0)
        {
            BlueLightTimer -= Time.deltaTime;
        }

        if (RedLightTimer > 0)
        {
            RedLightTimer -= Time.deltaTime;
        }

        if (GreenLightTimer > 0)
        {
            GreenLightTimer -= Time.deltaTime;
        }

    }
}
