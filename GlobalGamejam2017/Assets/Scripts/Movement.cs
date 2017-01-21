using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Movement : MonoBehaviour {

    private bool Freeze = false;
    private Vector3 moveVector;
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
        TryMove(leftStick);
    }

    private void FixedUpdate()
    {
        physics.AddForce(moveVector * 150);
        FixSpeed();
        moveVector = Vector3.zero;
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
            if (leftStick.y > 0.1f || leftStick.y < 0.1f)
                moveVector.z = leftStick.y * Time.deltaTime * speed;

            if (leftStick.x > 0.1f || leftStick.x < 0.1f)
                moveVector.x = leftStick.x * Time.deltaTime * speed;
        }
    }

}
