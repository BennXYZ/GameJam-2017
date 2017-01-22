using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buttons : MonoBehaviour {

    [SerializeField]
    UnityEvent onTrigger;

    [SerializeField]
    UnityEvent onRemove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Box")
            onTrigger.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
            onRemove.Invoke();
    }
}
