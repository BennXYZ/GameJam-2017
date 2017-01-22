using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    [Range(0,10)]
    private float EndHeight;

    [SerializeField]
    [Range(0,1)]
    private float MoveSpeed;

    private float startPosition;

    private float targetHeight;

    enum States { Open, Close }
    States state;

    public void OpenDoor()
    {
        targetHeight = startPosition - EndHeight;
    }

    public void CloseDoor()
    {
        targetHeight = startPosition;
    }

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position.y;
        targetHeight = startPosition;
        MoveSpeed = 1 / MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(0, (targetHeight - transform.position.y) / MoveSpeed, 0);


    }
}
