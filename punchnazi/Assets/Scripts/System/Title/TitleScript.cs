using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour {

	void Awake () {
		if (GameObject.Find("pSystem") != null){
            Destroy(GameObject.Find("pSystem"));
        }
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

}
