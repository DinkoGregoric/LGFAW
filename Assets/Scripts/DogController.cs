using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    private Rigidbody2D dogBody;
    public float jumpForce = 500f;

	// Use this for initialization
	void Start () {
        dogBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            dogBody.AddForce(transform.up * jumpForce);
        }
	}
}
