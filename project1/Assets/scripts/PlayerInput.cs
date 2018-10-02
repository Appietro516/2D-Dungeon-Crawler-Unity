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
    
    private bool attack_state = false;

	// Use this for initialization
	void Start () {
        sword_anim.Play("idle");
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal =  Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed  * Time.deltaTime;
        bool attack = Input.GetAxis("Fire1")  > 0f;
        
        
        Vector3 deltaMove = new Vector3(horizontal, vertical, 0);
        
        
        //since the game is top down, the player should control horizontal and vertical movement.
        player.position += deltaMove;
        
        
        if (vertical != 0){
            player.localScale = new Vector3(player.localScale.x, Math.Sign(-1 * vertical) * Math.Abs(player.localScale.y),  player.localScale.z);
        }
        
        if (horizontal != 0){
            player.localScale = new Vector3(Math.Sign(-1 * horizontal) * Math.Abs(player.localScale.x), player.localScale.y,  player.localScale.z);
        }
        
    
        
        if (attack && !attack_state){
             sword_anim.Play("sword_swing");
             sound_player.PlayOneShot(sword_sound);
        }
        
        
        
        
        attack_state = attack;
        
        
        
        
        
		
	}
}
