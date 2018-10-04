using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_door : MonoBehaviour {
    
    public Room room;
    public GameObject target_room;
    public Transform target_door;
    public GameObject leaving_room;
    
    
	// Use this for initialization
	void Start () {
        leaving_room = room.gameObject;
        if (this.gameObject == room.south_door){
            GameObject target_room = room.south_room;
            GameObject target_door = target_room.GetComponent<Room>().north_door;
            
        }
        if (this.gameObject == room.north_door){
            GameObject target_room = room.north_room;
            GameObject target_door = target_room.GetComponent<Room>().south_door;
            
        }
        if (this.gameObject == room.east_door){
            GameObject target_room = room.east_room;
            GameObject target_door = target_room.GetComponent<Room>().west_door;
            
        }
        if (this.gameObject == room.west_door){
            GameObject target_room = room.west_room;
            GameObject target_door = target_room.GetComponent<Room>().east_door;
            
        }
        
        if (target_room == null){
            print("empty door");
            this.gameObject.SetActive(false);
        }
		
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
