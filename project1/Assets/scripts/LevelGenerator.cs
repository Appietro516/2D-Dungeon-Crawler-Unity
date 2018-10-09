using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

	public GameObject room;
	public GameObject player;
	public GameObject rock;
	public GameObject exit_room;
	public GameObject potion;
	public GameObject trap;

	public static int level_num = 0;
	public static int points_cap = 50;
	public int distance = 100;
	public int max_x = 5;
	public int max_y = 5;

	private int remaining_points;
	private static bool loaded = false;

	void Awake(){
		if (!loaded){
			DontDestroyOnLoad(this.gameObject);
			loaded = true;
		}
		else{
			Destroy(this.gameObject);
		}

	}

	void OnEnable()
   {
	   SceneManager.sceneLoaded += OnSceneLoaded;
   }
	// Use this for initialization
	void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (scene.name != "basic_level"){
			return;
		}
		Text level = GameObject.Find("level_text").GetComponent<Text>();
		level_num++;
		level.text = "LEVEL: " + level_num;
		remaining_points = points_cap;
		int pos_x = max_x/2;
		int pos_y = max_y/2;
		Vector3 pos = new Vector3(pos_x*distance, pos_y*distance, 0);
		GameObject current_room = Instantiate(room, pos, Quaternion.identity);
		GameObject p1 = Instantiate(player, pos, Quaternion.identity);


		GameObject next_room = current_room;
		int new_pos_x = pos_x;
		int new_pos_y = pos_y;
		int i = 1000;
		bool east_room = false;
		bool west_room = false;
		bool north_room = false;
		bool south_room = false;
		bool exit = false;
		while (remaining_points > 0 || !exit){
			i--;
			if(i < 0){
				print("YOU SCREWED UP");
				return;
			}
			east_room = false;
			west_room = false;
			north_room = false;
			south_room = false;
			if ((Random.Range(0,100)< 25) && (current_room.GetComponent<Room>().east_room.GetComponent<Room>().dummy == true)){
				if (remaining_points <= 0){
					exit = true;
				}
				pos_x = pos_x + 1;
				pos = new Vector3(pos_x*distance, pos_y*distance, 0);
				if (!exit){
					next_room = Instantiate(room, pos, Quaternion.identity);
					populate_room(next_room);
				}
				else{
					next_room = Instantiate(exit_room, pos, Quaternion.identity);
				}
				next_room.SetActive(false);
				current_room.GetComponent<Room>().east_room = next_room;
				next_room.GetComponent<Room>().west_room = current_room;
				remaining_points -= 10;
				east_room = true;
				if (exit){
					continue;
				}
			}
			if ((Random.Range(0,100)< 25) && (current_room.GetComponent<Room>().west_room.GetComponent<Room>().dummy == true)){
				if (remaining_points <= 0){
					exit = true;
				}
				pos_x = pos_x - 1;
				pos = new Vector3(pos_x*distance, pos_y*distance, 0);
				if (!exit){
					next_room = Instantiate(room, pos, Quaternion.identity);
					populate_room(next_room);
				}
				else{
					next_room = Instantiate(exit_room, pos, Quaternion.identity);
				}
				next_room.SetActive(false);
				current_room.GetComponent<Room>().west_room = next_room;
				next_room.GetComponent<Room>().east_room = current_room;
				remaining_points -= 10;
				west_room = true;
				if (exit){
					continue;
				}
			}

			if ((Random.Range(0,100)< 25) && (current_room.GetComponent<Room>().north_room.GetComponent<Room>().dummy == true)){
				if (remaining_points <= 0){
					exit = true;
				}
				pos_y = pos_y + 1;
				pos = new Vector3(pos_x*distance, pos_y*distance, 0);
				if (!exit){
					next_room = Instantiate(room, pos, Quaternion.identity);
					populate_room(next_room);
				}
				else{
					next_room = Instantiate(exit_room, pos, Quaternion.identity);
				}
				next_room.SetActive(false);
				current_room.GetComponent<Room>().north_room = next_room;
				next_room.GetComponent<Room>().south_room = current_room;
				remaining_points -= 10;
				north_room = true;
				if (exit){
					continue;
				}
			}

			if ((Random.Range(0,100)< 25) && (current_room.GetComponent<Room>().south_room.GetComponent<Room>().dummy == true)){
				if (remaining_points <= 0){
					exit = true;
				}
				pos_y = pos_y + 1;
				pos = new Vector3(pos_x*distance, pos_y*distance, 0);
				if (!exit){
					next_room = Instantiate(room, pos, Quaternion.identity);
					populate_room(next_room);
				}
				else{
					next_room = Instantiate(exit_room, pos, Quaternion.identity);
				}
				next_room.SetActive(false);
				current_room.GetComponent<Room>().south_room = next_room;
				next_room.GetComponent<Room>().north_room = current_room;
				remaining_points -= 10;
				south_room = true;
				if (exit){
					continue;
				}
			}
			current_room = next_room;
		}



	}

	// Update is called once per frame
	void Update () {

	}
	private void populate_room(GameObject room){
		int health_room = Random.Range(0,10);
		if (health_room == 1){
			GameObject current_potion = Instantiate(potion, Vector3.zero, Quaternion.identity);
			current_potion.transform.parent = room.transform;
			current_potion.transform.localPosition = new Vector3(1,0,0);
			print("made health room");
			return;
		}

		int enemy_num = Random.Range(0,5);
		while(enemy_num > 0){
			GameObject current_enemy = Instantiate(trap, Vector3.zero, Quaternion.identity);
			EnemyMovement enemy_move = current_enemy.GetComponent<EnemyMovement>();
			int direction = Random.Range(0,2);
			if (direction == 0){
				enemy_move.speed_hor = 0;
				enemy_move.speed_vert = Random.Range(10,35);
			}
			else{
				enemy_move.speed_hor = Random.Range(10,35);
				enemy_move.speed_vert = 0;
			}
			current_enemy.transform.parent = room.transform;
			current_enemy.transform.localPosition = new Vector2(Random.Range(-4,4),Random.Range(-4,4));
			enemy_num--;
		}


		int rock_num = Random.Range(0,6);
		while (rock_num > 0){
			GameObject current_rock = Instantiate(rock, Vector3.zero, Quaternion.identity);
			current_rock.transform.parent = room.transform;
			current_rock.transform.localPosition = new Vector2(Random.Range(-6,6),Random.Range(-6,6));
			rock_num--;
		}

	}
}
