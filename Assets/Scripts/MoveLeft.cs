using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour {

    private AudioSource[] audios;
    public AudioSource bite;
    public AudioSource bad;
    public Text score;
    public Text[] scores;
    private static int numScore = 0;
    public HealthBarModifier hBModifier;
    public float speed = 5f;

    // Use this for initialization
    void Start () {
        scores = FindObjectsOfType<Text>();
        foreach (Text text in scores) {
            if (text.name.Equals("NumberScore")) {
                score = text;
            }
        }

        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        audios = GameObject.FindObjectsOfType<AudioSource>();
        foreach(AudioSource aSource in audios) {
            if (aSource.name.Equals("Bite")) {
                bite = aSource;
            }
            if (aSource.name.Equals("EatGarbage")) {
                bad = aSource;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Dog") {
            if (this.tag == "Poison") {
                numScore = numScore - 50;
                print(numScore);
                score.text = numScore.ToString();
                hBModifier.ChangeHBar(1);
                bad.Play();
                
            }

            if (hBModifier.getSpriteIndex() != 0) {
                if (this.tag == "Consumable") {
                    numScore = numScore + 100;
                    print(numScore);
                    score.text = numScore.ToString();
                    hBModifier.ChangeHBar(-1);
                    bite.Play();
                    
                }
            } else {
                numScore = numScore + 100;
                print(numScore);
                score.text = numScore.ToString();
                bite.Play();
                
            }
        }

        Destroy(gameObject);
    }
}
