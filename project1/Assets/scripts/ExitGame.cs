using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {

	public Button exit;
	void Start () {
        exit.onClick.AddListener(Quit);

	}


    public void Quit(){
        Application.Quit();
    }
}
