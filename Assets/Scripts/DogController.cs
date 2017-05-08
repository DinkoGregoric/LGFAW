using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DogController : MonoBehaviour {

    private HealthBarModifier hBModifier;
    private Rigidbody2D dogBody;
    private Animator dogAnimation;
    public AudioSource jump;
    public AudioSource faint;
    public float jumpForce = 500f;
    private float dogHurtTimer = -1;
    private Text num_score;
    private Text[] num_scores;

    private Camera camera;

	// Use this for initialization
	void Start () {
        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        dogBody = GetComponent<Rigidbody2D>();
        dogAnimation = GetComponent<Animator>();

        num_scores = FindObjectsOfType<Text>();
        foreach (Text text in num_scores) {
            if (text.name.Equals("NumberScore")) {
                num_score = text;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(dogHurtTimer == -1) {

            if (hBModifier.getSpriteIndex() == 4) {
                stopCamera();
                faint.Play();
                setScore();
            }

            if (dogBody.velocity.y == 0) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    dogBody.AddForce(transform.up * jumpForce);
                    jump.Play();
                }
            }

            dogAnimation.SetFloat("vertVelocity", Mathf.Abs(dogBody.velocity.y));
        } else {
            if(Time.time > dogHurtTimer + 1.5) {
                SceneManager.LoadScene("End_screen");
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Obstacle") {
            stopCamera();
            faint.Play();
            setScore();

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

    private void setScore() {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        int game_score = int.Parse(num_score.text);

        if (game_score > currentHighScore) {
            PlayerPrefs.SetInt("HighScore", game_score);
        }
    }

    
}
