using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XInputDotNetPure;


public class Triggersignal : MonoBehaviour {

    GameObject seeingEnvironmentSphere;
    GameObject seeingEnemiesSphere;
    GameObject seeingPuzzlesSphere;

    SoundSignal seeingEnvironmentSphereScript;
    SoundSignal seeingEnemiesSphereScript;
    SoundSignal seeingPuzzlesSphereScript;

    [SerializeField]
    private float BlueSoundCooldown = 1;
    private float BlueSoundTimer;

    [SerializeField]
    private float RedSoundCooldown = 1;
    private float RedSoundTimer;

    [SerializeField]
    private float GreenSoundCooldown = 1;
    private float GreenSoundTimer;

    AudioSource[] PlayerSounds;

    // Use this for initialization
    void Start () {
        seeingEnvironmentSphere = GameObject.FindGameObjectWithTag("SeeEnvironmentSphere");
        seeingEnemiesSphere = GameObject.FindGameObjectWithTag("SeeEnemiesSphere");
        seeingPuzzlesSphere = GameObject.FindGameObjectWithTag("SeePuzzlesSphere");

        PlayerSounds = gameObject.GetComponents<AudioSource>();
        BlueSoundTimer = BlueSoundCooldown;

        seeingEnvironmentSphereScript = seeingEnvironmentSphere.GetComponent<SoundSignal>();
        seeingEnemiesSphereScript = seeingEnemiesSphere.GetComponent<SoundSignal>();
        seeingPuzzlesSphereScript = seeingPuzzlesSphere.GetComponent<SoundSignal>();


    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimers();
        
        if ((GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed && BlueSoundTimer <= 0) || Input.GetButtonDown("Blue"))
        {

            //PlayerSounds[0].Play();
            BlueSoundTimer = BlueSoundCooldown;
            seeingEnvironmentSphere.transform.position = gameObject.transform.position;
            seeingEnvironmentSphereScript.Reset();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && GreenSoundTimer <= 0)
        {
            //PlayerSounds[0].Play();
            GreenSoundTimer = GreenSoundCooldown;
            seeingPuzzlesSphere.transform.position = gameObject.transform.position;
            seeingPuzzlesSphereScript.Reset();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed && RedSoundTimer <= 0)
        {
            //PlayerSounds[0].Play();
            RedSoundTimer = RedSoundCooldown;
            seeingEnemiesSphereScript.transform.position = gameObject.transform.position;
            seeingEnemiesSphereScript.Reset();
        }
    }

    void UpdateTimers()
    {
        if (BlueSoundTimer > 0)
        {
            BlueSoundTimer -= Time.deltaTime;
        }

        if (RedSoundTimer > 0)
        {
            RedSoundTimer -= Time.deltaTime;
        }

        if (GreenSoundTimer > 0)
        {
            GreenSoundTimer -= Time.deltaTime;
        }

    }
}
