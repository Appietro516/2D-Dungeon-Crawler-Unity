using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSript : MonoBehaviour {
    
    public Transform target_door;
    public GameObject target_room;
    public GameObject leaving_room;
    
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D col){
        PlayerInput inp = col.gameObject.GetComponent<PlayerInput>();
        if(inp){
            inp.gameObject.transform.position = new Vector2(target_door.position.x, target_door.position.y) + inp.dir.normalized * 2;
            target_room.SetActive(true);
            leaving_room.SetActive(false);
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
    }
}
