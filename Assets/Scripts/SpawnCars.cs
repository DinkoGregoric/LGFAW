using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour {

    private float nextSpawn = 0;
    public Transform carToSpawn;
    public AnimationCurve spawn_curve;
    public float curve_seconds = 60f;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
            Instantiate(carToSpawn, transform.position, Quaternion.identity);

            float curve = (Time.time - startTime) / curve_seconds;

            if (curve > 1) {
                curve = 1;
            }

            nextSpawn = Time.time + spawn_curve.Evaluate(curve);

            //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }

    }
}
