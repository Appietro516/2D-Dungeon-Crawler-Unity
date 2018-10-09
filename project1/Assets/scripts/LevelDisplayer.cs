using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayer : MonoBehaviour {

	public Text text_box;
	void Start () {
		text_box.text = "You made it to level " + LevelGenerator.level_num + "!";

		LevelGenerator.level_num = 0;
		LevelGenerator.points_cap = 50;
	}

	// Update is called once per frame
	void Update () {

	}
}
