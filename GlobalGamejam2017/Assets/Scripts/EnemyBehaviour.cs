using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBehaviour : MonoBehaviour {

    GameObject player;
    Rigidbody rigid;

    [SerializeField]
    float speed;

    [SerializeField]
    float distanceToPlayer;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private float FairTimeCooldown;

    private float FairTime= 0;

    [SerializeField]
    AudioSource impulse;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (player != null && FairTime <= 0)
            if (Vector3.Distance(transform.position, player.transform.position) < distanceToPlayer)
            {
                transform.LookAt(new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z));
                rigid.AddForce(transform.forward*10);
            }
        if (rigid.velocity.magnitude > speed)
            rigid.velocity = rigid.velocity.normalized * speed;
        if (FairTime > 0)
            FairTime -= Time.deltaTime;
        if (health <= 0)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoundWave")
            Interact();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FairTime = FairTimeCooldown;
        }
    }

    private void Interact()
    {
        health--;
    }
}