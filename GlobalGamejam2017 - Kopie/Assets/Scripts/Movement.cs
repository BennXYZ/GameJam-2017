using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Movement : MonoBehaviour {

    private bool Freeze = false;
    private Vector3 moveVector;
    private Vector3 rotateVector;
    [SerializeField]
    private float speed = 0;
    Rigidbody physics;
    GamePadState gamePad;

    [SerializeField]
    private float maxSpeed = 1;

	// Use this for initialization
	void Start () {
        physics = GetComponent<Rigidbody>();
        maxSpeed = maxSpeed/5;
    }
	
	// Update is called once per frame
	void Update () {
        gamePad = GamePad.GetState(PlayerIndex.One);
        Vector2 leftStick = new Vector2(gamePad.ThumbSticks.Left.X, gamePad.ThumbSticks.Left.Y);
        Vector2 rightStick = new Vector2(gamePad.ThumbSticks.Right.X, gamePad.ThumbSticks.Right.Y);
        TryMove(leftStick);
        TryRotate(rightStick);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(1,0,0) * moveVector.y);
        transform.Translate(new Vector3(0, 0, -moveVector.x));
        FixSpeed();
        moveVector = Vector3.zero;

        transform.Rotate(rotateVector);
    }

    private void FixSpeed()
    {
        if (physics.velocity.magnitude > maxSpeed)
        {
            physics.velocity = physics.velocity.normalized * maxSpeed;
        }
    }

    private void TryMove(Vector2 leftStick)
    {
        if (!Freeze)
        {
            moveVector = new Vector3(leftStick.x * Time.deltaTime * speed, leftStick.y * Time.deltaTime * speed);
        }
    }

    private void TryRotate(Vector2 rightStick)
    {
        if(!Freeze)
        {
            rotateVector = new Vector3(0, rightStick.x, 0);
        }
    }

}
