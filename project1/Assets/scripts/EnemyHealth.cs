using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health;
    
    
    private int deltaHealth;
    
    
    public void change_hp(int deltaHP){
        this.health += deltaHP;
    }
     
    void Update(){
        this.update_health();
        this.check_dead();
    }
    
    private void update_health(){
    }
    
    private void check_dead(){
        if (health <= 0){
            print("You Died!");
            gameObject.SetActive(false);
        }
        
    }
    
}

