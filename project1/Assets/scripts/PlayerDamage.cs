using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public bool in_range = false;
    public int range_pos = -2;
    public PlayerInput p_control;
    
    private EnemyHealth health;
    
	void OnTriggerEnter2D(Collider2D col){
        health = col.gameObject.GetComponent<EnemyHealth>();
        
        if (health != null){
            in_range = true;
        
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
         health = col.gameObject.GetComponent<EnemyHealth>();
        
        if (health != null){
            in_range = false;
        }
    }
    
    public void damage(){
        if (in_range){
            print("DOING DMG");
            health.change_hp(-1);
        }
        
    }
    
    void Update(){
        
    }
    
 
}
