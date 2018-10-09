using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathToMenu : MonoBehaviour {

		public Button continue_button;
		void Start () {
	        continue_button.onClick.AddListener(load_menu);

		}


	    public void load_menu(){
			print("Got to menu");
	        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	    }

}
