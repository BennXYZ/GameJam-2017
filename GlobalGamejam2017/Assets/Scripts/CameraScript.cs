using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CameraScript : MonoBehaviour {

    GameObject player;
   
    [SerializeField]
    private Vector3 offSet;
    private Rigidbody rigid;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        //transform.position = transform.position + (player.transform.position - (rotation * offSet) - transform.position) / 10;
        rigid.AddForce((player.transform.position - (rotation * offSet) - transform.position) * 100);
        rigid.velocity = rigid.velocity / 2;
    }

    // Update is called once per frame
    void Update() {


        //if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.2f || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.2f)
        //    offSet.y += GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * 0.1f;

        transform.LookAt(player.transform);
    }

    

}
