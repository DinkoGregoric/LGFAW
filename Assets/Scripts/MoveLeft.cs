﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour {

    public HealthBarModifier hBModifier;
    public float speed = 5f;

    // Use this for initialization
    void Start () {
        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if (hBModifier.getSpriteIndex() == 4) {
            SceneManager.LoadScene("Game");
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Dog") {
            if (this.tag == "Poison") {
                hBModifier.ChangeHBar(1);
            }

            if (hBModifier.getSpriteIndex() != 0) {
                if (this.tag == "Consumable") {
                    hBModifier.ChangeHBar(-1);
                }
            }
        }   

        if (hBModifier.getSpriteIndex() == 4) {
            SceneManager.LoadScene("Game");
        }
    }
}
