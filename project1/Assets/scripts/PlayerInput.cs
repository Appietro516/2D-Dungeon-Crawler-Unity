using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerInput : MonoBehaviour {
    
    public Transform player;
    public float speed;
    public Animator sword_anim;
    
    public AudioClip sword_sound;
    public AudioSource sound_player;
    
    public SpriteRenderer sprite_source;
    
    
    public Sprite front;
    public Sprite back;
    public Sprite side;
    
    
    public Vector2 dir;
    
    public PlayerDamage dmg_sys;
    
    private bool attack_state = false;

	// Use this for initialization
	void Start () {
        sword_anim.Play("idle");
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal =  Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed  * Time.deltaTime;
        if(Math.Abs(vertical) > 0.05 || Math.Abs(horizontal) > 0.05){
            dir = new Vector2(horizontal, vertical).normalized;
            print(dir);
        }
        bool attack = Input.GetAxis("Fire1")  > 0f;
        
        
        Vector3 deltaMove = new Vector3(horizontal, vertical, 0);
        
        
        //since the game is top down, the player should control horizontal and vertical movement.
        player.position += deltaMove;
        
        
        if (Math.Sign(vertical) == -1){
            sprite_source.sprite = front;
            //player.localScale = new Vector3(player.localScale.x, player.localScale.y * Math.Sign(-1 * vertical),  player.localScale.z);
        }
        else if(Math.Sign(vertical) == 1){
            sprite_source.sprite = back;
            //player.localScale = new Vector3(player.localScale.x, player.localScale.y * Math.Sign(-1 * vertical),  player.localScale.z);
        }
        
        if (horizontal != 0){
            sprite_source.sprite = side;
            player.localScale = new Vector3(Math.Sign(-1 * horizontal) * Math.Abs(player.localScale.x), player.localScale.y,  player.localScale.z);
        }
        
    
        
        if (attack && !attack_state){
             sword_anim.Play("sword_swing");
             sound_player.PlayOneShot(sword_sound);;
             dmg_sys.damage();
        }
        
        
        
        
        attack_state = attack;
        
        
        
        
        
		
	}
}
