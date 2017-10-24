
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTitleScript : MonoBehaviour {

	private Animator anim;
    private bool click;

	void Start () {
        click = false;
		anim = GetComponent<Animator>();
        Cursor.visible = false;
	}
	
	void Update () {
		click = false;
        click = Input.GetMouseButtonDown(0);
        if (click){
            Cursor.visible = false;
        }

        Vector3 v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.z = -50f;
        transform.position = v3;
        Vector2 mPos = new Vector2(transform.position.x, transform.position.y);

        string sprite_image = "aCursor";
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        for (int b = 0; b < buttons.Length; b++){
            if (buttons[b].GetComponent<Collider2D>().OverlapPoint(mPos)){
                sprite_image = "aInspect";
                if (click){
                    buttons[b].GetComponent<TitleButtonScript>().button();
                    break;
                }
            }
        }

        anim.Play(sprite_image);
	}
}
