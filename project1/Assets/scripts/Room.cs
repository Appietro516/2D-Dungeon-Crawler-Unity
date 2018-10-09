using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public GameObject west_room;
    public GameObject east_room;
    public GameObject north_room;
    public GameObject south_room;

    public GameObject north_door;
    public GameObject south_door;
    public GameObject east_door;
    public GameObject west_door;

    //establish as a dummy room for null pointers
    public bool dummy = false;


	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}
}
