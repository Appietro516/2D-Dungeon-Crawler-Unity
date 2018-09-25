using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public GameObject[] hearts;
    
    private int deltaHealth;
    private int heart_num = 0;
    
    
    public void change_hp(int deltaHP){
        this.deltaHealth = deltaHP;
        this.health += this.deltaHealth;
    }
     
    void Update(){
        this.update_health();
        this.check_dead();
    }
    
    private void update_health(){
        if (this.deltaHealth != 0){
            if (deltaHealth > 0){
                heart_num -= deltaHealth;
            }
            this.hearts[this.heart_num].SetActive(!this.hearts[this.heart_num].activeSelf);
            if (deltaHealth < 0){
                heart_num -= deltaHealth;
            }
            this.deltaHealth = 0;
        }
    }
    
    private void check_dead(){
        if (health <= 0){
            print("You Died!");
            gameObject.SetActive(false);
        }
        
    }
    
}

