using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatable : MonoBehaviour
{

    [SerializeField]
    Vector3 movingToVector;

    Vector3 startingPosition;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float stayingTime;
    private float stayingCooldown;

    enum States { stayingAtStart, movingToEnd,stayingAtEnd, movingToStart};
    States state;


    // Use this for initialization
    void Start()
    {
        state = States.stayingAtStart;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.stayingAtStart:
                state = StayingAtStart();
                break;
            case States.movingToEnd:
                state = MovingToEnd();
                break;
            case States.stayingAtEnd:
                state = StayingAtEnd();
                break;
            case States.movingToStart:
                state = MovingToStart();
                break;
        }
    }

    private States MovingToStart()
    {
        if (Vector3.Distance(transform.position, transform.position - movingToVector * Time.deltaTime * movementSpeed * 10) <
            Vector3.Distance(transform.position, startingPosition))
            transform.Translate(- movingToVector * Time.deltaTime * movementSpeed*10);
        else
        {
            transform.position = startingPosition;
            return States.stayingAtStart;
        }
        return States.movingToStart;
    }

    private States StayingAtEnd()
    {
        stayingCooldown -= Time.deltaTime;
        if(stayingCooldown <= 0)
        {
            stayingCooldown = stayingTime;
            return States.movingToStart;
        }
        return States.stayingAtEnd;
    }

    private States MovingToEnd()
    {
        if (Vector3.Distance(transform.position, transform.position + movingToVector * Time.deltaTime * movementSpeed * 10) <
            Vector3.Distance(transform.position, startingPosition + movingToVector))
        transform.Translate(movingToVector * Time.deltaTime * movementSpeed* 10);
        else
        {
                transform.position = startingPosition + movingToVector;
            stayingCooldown = stayingTime;
            return States.stayingAtEnd;
        }
        return States.movingToEnd;
    }

    private States StayingAtStart()
    {
        return States.stayingAtStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundWave")
            Interact();
        if (other.gameObject.tag == "Player")
            other.gameObject.transform.SetParent(gameObject.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    private void Interact()
    {
        if (state == States.stayingAtStart)
            state = States.movingToEnd;
    }
}
