using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour {

    private AudioSource[] audios;
    public AudioSource bite;
    public AudioSource bad;
    public HealthBarModifier hBModifier;
    public float speed = 5f;

    // Use this for initialization
    void Start () {
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
                hBModifier.ChangeHBar(1);
                bad.Play();
                print("BAD");
            }

            if (hBModifier.getSpriteIndex() != 0) {
                if (this.tag == "Consumable") {
                    hBModifier.ChangeHBar(-1);
                    bite.Play();
                    print("ATE");
                }
            } else {
                bite.Play();
                print("ATE");
            }
        }

        Destroy(gameObject);
    }
}
