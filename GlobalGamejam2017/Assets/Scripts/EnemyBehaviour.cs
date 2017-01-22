using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBehaviour : MonoBehaviour {

    GameObject player;
    Rigidbody rigid;

    [SerializeField]
    float speed;
    float currentSpeed;

    [SerializeField]
    float distanceToPlayer;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private float FairTimeCooldown;

    private float FairTime= 0;

    [SerializeField]
    AudioSource impulse;

    [SerializeField]
    GameObject[] pivots;
    int nextPivot;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody>();
        if (pivots.Length != 0)
            nextPivot = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        if (player != null && FairTime <= 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < distanceToPlayer)
            {
                currentSpeed = speed;
                transform.LookAt(new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z));
                rigid.AddForce(transform.forward * 10);
            }
            else if(pivots.Length > 0)
                Patrol();
        }

        if (rigid.velocity.magnitude > currentSpeed)
            rigid.velocity = rigid.velocity.normalized * currentSpeed;
        if (FairTime > 0)
            FairTime -= Time.deltaTime;
        if (health <= 0)
            Destroy(gameObject);
	}

    void Patrol()
    {
        currentSpeed = speed / 2;

        transform.LookAt(new Vector3(pivots[nextPivot].transform.position.x, gameObject.transform.position.y, pivots[nextPivot].transform.position.z));
        rigid.AddForce(transform.forward * 10);
        if (Vector3.Distance(pivots[nextPivot].transform.position, transform.position) < 1)
            nextPivot++;
        if (nextPivot + 1 > pivots.Length)
            nextPivot = 0;

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