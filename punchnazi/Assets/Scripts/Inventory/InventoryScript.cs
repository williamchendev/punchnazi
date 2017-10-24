using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

    public GameObject item_pref;
    public GameObject clock_pref;
    public GameObject timetext_pref;
    public GameObject areatext_pref;

    private Animator anim;
    private new string animation;
    private GameObject[] items;
    private GameObject clock;
    private GameObject time;
    private GameObject area;

    void Start () {
		anim = GetComponent<Animator>();
        animation = "aIdle";
        items = new GameObject[6];
        for (int i = 0; i < items.Length; i++){
            items[i] = Instantiate(item_pref, new Vector3(0.5f + (i * 1.25f), -3.6f, -48f), transform.rotation);
            items[i].GetComponent<ItemInvScript>().setShow(ManagerSystem.Instance.getCanMove());
            items[i].GetComponent<ItemInvScript>().setItem(ManagerSystem.Instance.getItem(i));
        }
        clock = Instantiate(clock_pref, new Vector3(-6.75f, -3.6f, -48f), transform.rotation);
        time = Instantiate(timetext_pref, new Vector3(-6.15f, -3.6f, -48f), transform.rotation);
        time.GetComponent<TextMesh>().text = ManagerSystem.Instance.getTime();
        area = Instantiate(areatext_pref, new Vector3(-2.55f, -3.6f, -48f), transform.rotation);
        if (GameObject.FindGameObjectWithTag("area") != null){
            area.GetComponent<TextMesh>().text = GameObject.FindGameObjectWithTag("area").GetComponent<AreaScript>().name;
        }
	}

    void Update () {
        bool draw_clock = false;
        if (animation != "aQuestion" && animation != "aQuestion3"){
            GetComponent<Renderer>().enabled = ManagerSystem.Instance.getCanMove();
            if (animation == "aIdle"){
                for (int i = 0; i < 6; i++){
                    items[i].GetComponent<ItemInvScript>().setShow(ManagerSystem.Instance.getCanMove());
                    items[i].GetComponent<ItemInvScript>().setItem(ManagerSystem.Instance.getItem(i));
                }
                draw_clock = ManagerSystem.Instance.getCanMove();
            }
        }
        else {
            GetComponent<Renderer>().enabled = true;
        }

        time.GetComponent<TextMesh>().text = ManagerSystem.Instance.getTime();
        clock.GetComponent<Renderer>().enabled = draw_clock;
        time.GetComponent<Renderer>().enabled = draw_clock;
        area.GetComponent<Renderer>().enabled = draw_clock;
    }

    public void changeSprite(string sprite_name){
        animation = sprite_name;
        anim.Play(sprite_name);
    }

}
