using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public GameObject[] hearts;
    public int i_frames;
    public SpriteRenderer player_sprite;

    private int deltaHealth;
    private int heart_num = 0;
    private bool i_frames_state = false;
    private int remaining_i_frames;

    void Awake(){
        hearts[0] = GameObject.Find("heart1");
        hearts[1] = GameObject.Find("heart2");
        hearts[2] = GameObject.Find("heart3");
    }

    public void change_hp(int deltaHP){
        if (i_frames_state && deltaHP < 0){
            return;
        }
        this.deltaHealth = deltaHP;
        this.health += this.deltaHealth;
        if (this.deltaHealth < 0){
            this.i_frames_state = true;
            this.remaining_i_frames = i_frames;
            InvokeRepeating("flash_sprite", 0.0f, 0.1f);

        }
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
        if (remaining_i_frames <= 0){
            this.i_frames_state = false;
            CancelInvoke();
            player_sprite.enabled = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }

    private void check_dead(){
        if (health <= 0){
            print("You Died!");
            SceneManager.LoadScene("DieScreen", LoadSceneMode.Single);
        }

    }

    private void flash_sprite(){
        player_sprite.enabled = !player_sprite.enabled;

    }

}
