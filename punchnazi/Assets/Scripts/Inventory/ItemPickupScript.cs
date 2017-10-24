using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupScript : MonoBehaviour {

    //Settings
    private int type;
    private string text;
	private float spd;
    private float alpha;
    private SpriteRenderer sr;

	void Start () {
        spd = 0.1f;
        alpha = 1f;
		Animator anim = GetComponent<Animator>();
        anim.Play(type + "");
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + spd, transform.position.z);
        spd -= 0.005f;

        if (alpha > 0.05){
            alpha *= 0.93f;
        }
        else {
            destroySelf();
        }

        Color tmp = sr.color;
        tmp.a = alpha;
        sr.color = tmp;
	}

    private void destroySelf(){
        ManagerSystem.Instance.createText(text);
        ManagerSystem.Instance.textInspect();
        ManagerSystem.Instance.addItem(type);
        Destroy(gameObject);
    }

    public void setText(string new_text){
        text = new_text;
    }

    public void setType(int new_type){
        type = new_type;
    }
}
