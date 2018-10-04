using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    public int speed_vert;
    public int speed_hor;
    
    private int dir = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = speed_hor * Time.deltaTime * dir;
        float vertical =  speed_vert * Time.deltaTime * dir;
		
        Vector3 deltaMove = new Vector3(horizontal, vertical, 0);
        gameObject.transform.position += deltaMove;

	}
    
    void OnCollisionEnter2D(Collision2D col){
        dir *= -1;
    }
}
