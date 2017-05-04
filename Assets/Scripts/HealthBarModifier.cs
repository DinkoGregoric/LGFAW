using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarModifier : MonoBehaviour {

    public Sprite[] healthSprites;
    private int spriteIndex = 0;


    public void ChangeHBar(int increment) {
        spriteIndex += increment;
        this.GetComponent<SpriteRenderer>().sprite = healthSprites[spriteIndex];
    }

    public int getSpriteIndex() {
        return spriteIndex;
    } 
}
