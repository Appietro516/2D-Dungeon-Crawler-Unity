using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDoor : MonoBehaviour {

    public Room room;
    public GameObject target_room;
    public GameObject target_door;
    public GameObject leaving_room;


	// Use this for initialization
	void Start () {
        leaving_room = room.gameObject;
        print(this.gameObject);
        print(room.south_door);
        if (this.gameObject == room.south_door){
            target_room = room.south_room;
            target_door = target_room.GetComponent<Room>().north_door;

        }
        if (this.gameObject == room.north_door){
            target_room = room.north_room;
            target_door = target_room.GetComponent<Room>().south_door;

        }
        if (this.gameObject == room.east_door){
            target_room = room.east_room;
            target_door = target_room.GetComponent<Room>().west_door;

        }
        if (this.gameObject == room.west_door){
            target_room = room.west_room;
            target_door = target_room.GetComponent<Room>().east_door;

        }

        if (target_room.GetComponent<Room>().dummy == true){
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
            inp.gameObject.transform.position = new Vector2(target_door.transform.position.x, target_door.transform.position.y) + inp.dir.normalized * 2;
            target_room.SetActive(true);
            leaving_room.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col){
    }
}
