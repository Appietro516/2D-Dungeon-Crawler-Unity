using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public GameObject[] hearts;
    public int i_frames;
    
    private int deltaHealth;
    private int heart_num = 0;
    private bool i_frames_state = false;    
    private int remaining_i_frames;
    
    public void change_hp(int deltaHP){
        if (i_frames_state && deltaHP < 0){
            return;
        }
        this.deltaHealth = deltaHP;
        this.health += this.deltaHealth;
        this.i_frames_state = true; 
        this.remaining_i_frames = i_frames;
    }
     
    void Update(){
        this.update_health();
        this.reset_i_frames();
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
    
    private void reset_i_frames(){
        if (i_frames_state){
            remaining_i_frames--;
        }
        if (remaining_i_frames == 0){
            this.i_frames_state = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }
    
    private void check_dead(){
        if (health <= 0){
            print("You Died!");
            gameObject.SetActive(false);
        }
        
    }
    
}

