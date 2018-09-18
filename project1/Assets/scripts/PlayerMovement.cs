using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public Transform player;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal =  Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed  * Time.deltaTime;
        
        //since the game is top down, the player should control horizontal and vertical movement.
        player.position += new Vector3(horizontal, vertical, 0);
        
		
	}
}
