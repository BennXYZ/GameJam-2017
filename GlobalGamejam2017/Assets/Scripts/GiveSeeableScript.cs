using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSeeableScript : MonoBehaviour {

    Mesh[] meshes;

	// Use this for initialization
	void Start () {
        meshes = GetComponentsInChildren<Mesh>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
