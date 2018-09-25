using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWin : MonoBehaviour {
    
    void Start(){
        print("Get to exit to win");
    }
    void OnTriggerEnter2D(Collider2D col){
        print("You Win!");
    }
}
