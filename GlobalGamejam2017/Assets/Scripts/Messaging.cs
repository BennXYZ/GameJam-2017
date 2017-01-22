using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Messaging : MonoBehaviour {

    [SerializeField]
    private Text messaging;
    private string emptyMessage = "";
    private string[] messages = new string[55];
    [SerializeField]
    public AudioSource deathscream;

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
        messages[17] = "Who built those statues?";
        messages[18] = "I can't stand it any longer!";
        messages[19] = "I am going back now!";
        messages[20] = "What is the last thing you remember?";
        messages[21] = "Imagine you are a sailor on a pirate ship...";
        messages[22] = "Keep going!";
        messages[23] = "Is this a game?";
        messages[24] = "When you are really far away, everything seems so small";
        messages[25] = "Home... oh sweet home...";
        messages[26] = "Who is to blame?";
        messages[27] = "They live...I don't!";
        messages[28] = "The lantern... I must reach it!";
        messages[29] = "Everybody must die";
        messages[30] = "Embrace the light";
        messages[31] = "I will be a better person, I promise!";
        messages[32] = "Breakfast at 9am";
        messages[33] = "More light!";
        messages[34] = "We're blasting off again";
        messages[35] = "To infinity and beyond!";
        messages[36] = "You died...";
        messages[37] = "If only we got a second opinion from another doctor...";
        messages[38] = "Hello from the other side";
        messages[39] = "Everything is fine...";
        messages[40] = "Nobody is listening";
        messages[41] = "Alone?";
        messages[42] = "What are those creepy things?";
        messages[43] = "Goodbye darling";
        messages[44] = "I am scared!";
        messages[45] = "Maybe we will meet again someday";
        messages[46] = "What is the reason for all of this?";
        messages[47] = "No escape!";
        messages[48] = "And again and again and again...";
        messages[49] = "Today I am sad";
        messages[50] = "It was not my time to go...";
        messages[51] = "For a brief moment I was free!";
        messages[52] = "What would you do if you could change your fate?";
        messages[53] = "Will I ever forget what happened?";
        messages[54] = "Someday you will understand...";

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
            deathscream.Play();
            other.gameObject.SetActive(false);
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
