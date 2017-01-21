using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour {

    GameObject soundWave;

	// Use this for initialization
	void Start () {
        soundWave = GameObject.FindGameObjectWithTag("SoundWave");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void interact()
    {

    }
}
