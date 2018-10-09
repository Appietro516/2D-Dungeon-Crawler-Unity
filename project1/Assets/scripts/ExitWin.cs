using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWin : MonoBehaviour {


    void Start(){
        print("Get to exit to win");
    }
    void OnTriggerEnter2D(Collider2D col){
        print("You win!");
        LevelGenerator.points_cap += 30;
        SceneManager.LoadScene("basic_level");
    }
}
