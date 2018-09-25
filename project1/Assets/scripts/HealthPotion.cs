using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {
    public GameObject potion;
    private bool used = false;
    
    
    void OnTriggerEnter2D(Collider2D col){
        PlayerHealth health = col.gameObject.GetComponent<PlayerHealth>();
        if (health != null){
            if (health.health < 3){
                health.change_hp(1);
                this.used = true;
            }
            else{
                print("Must take damage to use");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (used){
            potion.SetActive(false);
        }
		
	}
}
