using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour {

    public float nextSpawn;
    public Transform carToSpawn;
    public AnimationCurve spawn_curve;
    public float curve_seconds = 240f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > nextSpawn) {
            Instantiate(carToSpawn, transform.position, Quaternion.identity);

            float curve = (Time.timeSinceLevelLoad) / curve_seconds;

            if (curve > 1) {
                curve = 1;
            }

            nextSpawn = Time.timeSinceLevelLoad + spawn_curve.Evaluate(curve);

            //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }

    }
}
