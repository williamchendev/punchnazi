using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScript : MonoBehaviour {

	//Settings
    private bool inspect;
    private string text;
    private float time;
    private float spd;
    private TextMeshScript textmesh;

    //Inst
    public GameObject textmesh_pref;

	void Awake () {
		GameObject textmesh_obj = Instantiate(textmesh_pref, new Vector3(-6f, -2f, -26f), transform.rotation);
        textmesh = textmesh_obj.GetComponent<TextMeshScript>();
        text = "";
        spd = 0.35f;
        inspect = false;
	}
	
	void Update () {
        if (ManagerSystem.Instance.getClick()){
            if (time < text.Length){
                time = text.Length;
            }
            else {
                destroySelf();
            }
        }

		if (time < text.Length){
            time += spd;
        }

        string timed_text = text.Substring(0, (int) Mathf.Round(time));
        textmesh.changeText(timed_text);
	}

    public void changeText(string new_text){
        text = new_text;
    }

    public void inspectText(){
        inspect = true;
    }

    private void destroySelf(){
        if (inspect){
            ManagerSystem.Instance.setCanMove(true);
        }
        textmesh.destroySelf();
        Destroy(gameObject);
    }
}
