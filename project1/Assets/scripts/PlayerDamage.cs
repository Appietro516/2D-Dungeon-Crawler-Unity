using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public int range_pos = -2;
    
    private EnemyHealth health;
    
	void OnTriggerEnter2D(Collider2D col){
        health = col.gameObject.GetComponent<EnemyHealth>();
    }
    
    void OnTriggerExit2D(Collider2D col){
            health = null;
        }
    public void damage(){
        if (health){
            print("DOING DMG");
            health.change_hp(-1);
            health = null;
        }
        
    }
    
    void Update(){
        
    }
    
 
}
