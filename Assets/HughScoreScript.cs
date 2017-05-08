using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HughScoreScript : MonoBehaviour {

    public Text bestScore;

	// Use this for initialization
	void Start () {
        bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
