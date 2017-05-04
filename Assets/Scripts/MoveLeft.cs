using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour {

    public HealthBarModifier hBModifier;
    public float speed = 5f;
    public float hungerTime = 10;

	// Use this for initialization
	void Start () {
        hBModifier = GameObject.FindObjectOfType<HealthBarModifier>();
        /*StartCoroutine("MakeHimHungry");*/
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
        
        if(this.tag == "Poison") {
            hBModifier.ChangeHBar(1);
        }

        if (hBModifier.getSpriteIndex() != 0) {
            if (this.tag == "Consumable") {
                hBModifier.ChangeHBar(-1);
            }
        }
            

        if (hBModifier.getSpriteIndex() == 4) {
            SceneManager.LoadScene("Game");
        }
    }

   /* IEnumerator MakeHimHungry() {
        while (true) {
            if (hBModifier.getSpriteIndex() == 4) {
                SceneManager.LoadScene("Game");
            }
            
            yield return new WaitForSeconds(hungerTime);
            hBModifier.ChangeHBar(1);
        }
        
    }*/

}
