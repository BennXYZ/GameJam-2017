using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Messaging : MonoBehaviour {

    [SerializeField]
    private Text messaging;
    private string emptyMessage = "";
    private string[] messages = new string[20];

    float visibleTime = 0;
    [SerializeField]
    float maxVisibletime;

	// Use this for initialization
	void Start ()
    {
        //Dont show Message in beginning
        visibleTime = maxVisibletime + 1;

        //Fill up the Array
        messages[0] = "Is there anybody out there?";
        messages[1] = "I want to see my family again!";
        messages[2] = "Where am I?";
        messages[3] = "Please, help me";
        messages[4] = "This leads to nothing";
        messages[5] = "Leave me alone";
        messages[6] = "Here again?";
        messages[7] = "I did it!";
        messages[8] = "Nothing matters!";
        messages[9] = "Blind...I am blind...";
        messages[10] = "You can do it!";
        messages[11] = "Do not delay here!";
        messages[12] = "Get me outta here";
        messages[13] = "This is plain madness";
        messages[14] = "Why would you do this to us?";
        messages[15] = "We are all lost";
        messages[16] = "Why me?";
        messages[17] = "Statues?";
        messages[18] = "I can't stand it any longer!";
        messages[19] = "I am going back now!";
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(visibleTime >= maxVisibletime)
        {
            SetEmptyText();
        }
        

        visibleTime += Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Message"))
        {
            if(visibleTime >= maxVisibletime)
            {
                visibleTime = 0;
                SetText(GetRandomIndex());
            }
        }
    }

    private void SetText(int index)
    {
        messaging.text = messages[index];
    }
    private void SetEmptyText()
    {
        messaging.text = emptyMessage;
    }

    private int GetRandomIndex()
    {
        System.Random rand = new System.Random();
        return rand.Next(0, messages.Length);
    }
}
