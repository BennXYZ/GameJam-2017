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
        Debug.Log("lol");
        targetHeight = transform.position.y - EndHeight;
    }

    public void CloseDoor()
    {
        Debug.Log("wut");
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
        if (targetHeight > transform.position.y)
            transform.Translate(0, (targetHeight - transform.position.y) / MoveSpeed, 0);
        if (targetHeight < transform.position.y)
            transform.Translate(0, (targetHeight + transform.position.y) / MoveSpeed, 0);

    }
}
