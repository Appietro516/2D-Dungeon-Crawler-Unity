using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    
    public Transform player;
    public float speed;
    
    private bool attack_state = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal =  Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed  * Time.deltaTime;
        bool attack = Input.GetAxis("Fire1")  > 0f;
        
        Vector3 deltaMove = new Vector3(horizontal, vertical, 0);
        
        
        //since the game is top down, the player should control horizontal and vertical movement.
        player.position += deltaMove;
        
        
        
        if (attack && !attack_state){
            print("attack!");
        }
        
        attack_state = attack;
        
        
        
        
        
		
	}
}
