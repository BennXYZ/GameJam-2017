using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private float health;
    private BoxCollider boxCollider;
    Rigidbody rigid;
    Transform direction;

    [SerializeField]
    float fallSpeedVibes;

    private float vibrationStrength;

    [SerializeField]
    [Range(0,1)]
    private float pushStrength;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rigid = GetComponent<Rigidbody>();
        direction = gameObject.transform;
        vibrationStrength = 0;
    }

    void Update()
    {
        UpdateVibrations();
        UpdateFallVibs();
	}

    private void UpdateFallVibs()
    {
        if (-rigid.velocity.y > fallSpeedVibes)
            vibrationStrength = (-rigid.velocity.y - fallSpeedVibes) * 0.2f;
        if (vibrationStrength > 1)
            vibrationStrength = 1;

    }

    void UpdateVibrations()
    {
        if (vibrationStrength >= 0.08)
            vibrationStrength -= 0.02f;
        else
            vibrationStrength = 0;
        GamePad.SetVibration(PlayerIndex.One, vibrationStrength, vibrationStrength);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vibrationStrength = 1;
            direction = collision.gameObject.transform;
            direction.LookAt(gameObject.transform);
            rigid.AddForce(direction.forward * 1000 * pushStrength);
        }
    }
}
