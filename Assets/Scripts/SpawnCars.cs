using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour {

    private float nextSpawn = 0;
    public Transform carToSpawn;
    public float spawnRate = 3;
    public float randomDelay = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
            Instantiate(carToSpawn, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
	}
}
