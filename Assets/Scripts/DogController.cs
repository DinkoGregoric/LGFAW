using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour {

    private HealthBarModifier hBModifier;
    private Rigidbody2D dogBody;
    private Animator dogAnimation;
    public float jumpForce = 500f;
    private float dogHurtTimer = -1;

    private Camera camera;

	// Use this for initialization
	void Start () {
        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        dogBody = GetComponent<Rigidbody2D>();
        dogAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        if (hBModifier.getSpriteIndex() == 4) {
            stopCamera();
        }
        

        print(Time.timeSinceLevelLoad);

        if(dogHurtTimer == -1) {
            if (dogBody.velocity.y == 0) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    dogBody.AddForce(transform.up * jumpForce);
                }
            }

            dogAnimation.SetFloat("vertVelocity", Mathf.Abs(dogBody.velocity.y));
        } else {
            if(Time.time > dogHurtTimer + 1) {
                SceneManager.LoadScene("Game");
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Obstacle") {
            stopCamera();
        }
    }

    private void stopCamera() {
        foreach(SpawnCars spawner in FindObjectsOfType<SpawnCars>()) {
            spawner.enabled = false;
        }

        foreach (MoveLeft leftScript in FindObjectsOfType<MoveLeft>()) {
            leftScript.enabled = false;
        }


        dogAnimation.SetBool("dogHurt", true);
        dogHurtTimer = Time.time;
    }

    
}
