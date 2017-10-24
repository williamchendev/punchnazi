using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceScript : MonoBehaviour {

    //Settings
    public GameObject text_pref;

    public string type;
    public string text;
	private GameObject text_obj;

	void Start () {
        text_obj = Instantiate(text_pref, new Vector3(transform.position.x, transform.position.y, -47f), transform.rotation);
        text_obj.GetComponent<TextMesh>().text = text;
	}

    public void destroySelf(){
        Destroy(text_obj.gameObject);
        Destroy(gameObject);
    }

}
