using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private float health;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        foreach (GameObject tempObject in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Collider tempObjectCollider = tempObject.GetComponent<Collider>();
            if (boxCollider.bounds.Intersects(tempObjectCollider.bounds))
            {
                health -= 1;
            }
        }

        if(health <= 0)
        {
            SceneManager.LoadScene("Sebastian");
        }
	}
}
