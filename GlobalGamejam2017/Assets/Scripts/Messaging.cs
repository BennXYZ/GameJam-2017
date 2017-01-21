using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Messaging : MonoBehaviour {

    private Text messaging;
    private string message = "Halten Sie ihr Maul";

	// Use this for initialization
	void Start ()
    {
        messaging.text = "" + message;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Message"))
        {

        }
    }
}
