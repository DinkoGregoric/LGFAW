using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtDoggo : MonoBehaviour {

    public HealthBarModifier hBModifier;
    public float hungerTime = 10;
    private float lastTime;

    // Use this for initialization
    void Start () {
        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        lastTime = Time.timeSinceLevelLoad;
    }
	
	// Update is called once per frame
	void Update () {

        if (hBModifier.getSpriteIndex() == 4) {
            SceneManager.LoadScene("Game");
        }

        if (Time.timeSinceLevelLoad - lastTime > hungerTime) {
            lastTime = Time.timeSinceLevelLoad;
            print("CHANGED IT");
            hBModifier.ChangeHBar(1);

        }
    }

    public void setTime() {
        lastTime = Time.timeSinceLevelLoad;
    }
}
