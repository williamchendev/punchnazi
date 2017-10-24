using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvScript : MonoBehaviour {

    private int item;
	private new string name;
    private bool draw;

    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
        Update();
    }

    void Update() {
        if (draw){
            if (item != -1){
                anim.Play(item + "");
                GetComponent<Renderer>().enabled = true;
            }
            else {
                GetComponent<Renderer>().enabled = false;
            }
        }
        else {
            GetComponent<Renderer>().enabled = false;
        }
    }

    public void setItem(int type){
        item = type;
    }

    public void setShow(bool show){
        draw = show;
    }

}
