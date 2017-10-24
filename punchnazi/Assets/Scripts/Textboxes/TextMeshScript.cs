
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshScript : MonoBehaviour {

	private TextMesh textmesh;

	void Start () {
	    textmesh = GetComponent<TextMesh>();	
	}

    public void changeText(string new_text){
        textmesh.text = new_text;
    }

    public void destroySelf(){
        Destroy(gameObject);
    }
}
