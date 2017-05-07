using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {

    public Camera camera;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.timeSinceLevelLoad > 60) {
            camera.backgroundColor = new Color(colorNumberConversion(179), colorNumberConversion(193), colorNumberConversion(216));
        }

        if (Time.timeSinceLevelLoad > 120) {
            camera.backgroundColor = new Color(colorNumberConversion(165), colorNumberConversion(178), colorNumberConversion(199));
        }

        if (Time.timeSinceLevelLoad > 240) {
            camera.backgroundColor = new Color(colorNumberConversion(97), colorNumberConversion(115), colorNumberConversion(144));
        }
    }

    private float colorNumberConversion(float num) {
        return (num / 255.0f);
    }
}
