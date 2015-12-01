using UnityEngine;
using System.Collections;

public class daMenu : MonoBehaviour {

	public int sceneChanger;
	
	public void changeScene(int sceneChanger){
		Application.LoadLevel ("Nivel2");
	}
	
	public void exiter(){
		Application.Quit ();
	}

}
