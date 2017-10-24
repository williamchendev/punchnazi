using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorScript : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
        cursor();
	}

    void Update() {
        cursor();
    }

    private void cursor(){
        Vector3 v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.z = -50f;
        transform.position = v3;

        Vector2 mPos = new Vector2(transform.position.x, transform.position.y);
        bool check = false;
        string sprite_name = "aCursor";

        if (ManagerSystem.Instance.getCanMove()){

            GameObject[] items = GameObject.FindGameObjectsWithTag("item");
            for (int i = 0; i < items.Length; i++){
                if (items[i].GetComponent<Collider2D>().OverlapPoint(mPos)){
                    check = true;
                    sprite_name = "aHand";
                    
                    if (ManagerSystem.Instance.getClick()){
                        ItemScript item_info = items[i].GetComponent<ItemScript>();
                        ManagerSystem.Instance.createPickup(items[i].transform.position.x, items[i].transform.position.y, item_info.text, item_info.item);
                        ManagerSystem.Instance.setCanMove(false);
                        Destroy(items[i].gameObject);
                        break;
                    }
                }
            }

            if (!check){
                GameObject[] movement = GameObject.FindGameObjectsWithTag("movement");
                for (int m = 0; m < movement.Length; m++){
                    if (movement[m].GetComponent<Collider2D>().OverlapPoint(mPos)){
                        check = true;
                        string movement_direction = movement[m].GetComponent<MovementScript>().direction;
                        if (movement_direction == "up"){
                            sprite_name = "aUpEnter";
                        }
                        else if (movement_direction == "down"){
                            sprite_name = "aDownEnter";
                        }
                        else if (movement_direction == "left"){
                            sprite_name = "aLeftEnter";
                        }
                        else {
                            sprite_name = "aRightEnter";
                        }

                        if (ManagerSystem.Instance.getClick()){
                            SceneManager.LoadScene(movement[m].GetComponent<MovementScript>().scene_name);
                            ManagerSystem.Instance.reloadUI();
                            break;
                        }
                    }
                }
            }

            if (!check){
                GameObject[] ins = GameObject.FindGameObjectsWithTag("inspect");
                for (int i = 0; i < ins.Length; i++){
                    if (ins[i].GetComponent<Collider2D>().OverlapPoint(mPos)){
                        check = true;
                        sprite_name = "aInspect";

                        if (ManagerSystem.Instance.getClick()){
                            ManagerSystem.Instance.createText(ins[i].GetComponent<InspectScript>().text);
                            ManagerSystem.Instance.textInspect();
                            ManagerSystem.Instance.setCanMove(false);
                            break;
                        }
                    }
                }
            }

            if (!check){
                GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");
                for (int n = 0; n < npcs.Length; n++){
                    if (npcs[n].GetComponent<Collider2D>().OverlapPoint(mPos)){
                        check = true;
                        sprite_name = "aQuestion";
                    
                        if (ManagerSystem.Instance.getClick()){
                            npcs[n].GetComponent<NPCBehaviorScript>().talk();
                            break;
                        }
                    }
                }
            }
        }
        else {
            bool choicemade = false;
            GameObject[] cho = GameObject.FindGameObjectsWithTag("choice");
            for (int k = 0; k < cho.Length; k++){
                if (cho[k].GetComponent<Collider2D>().OverlapPoint(mPos)){
                    sprite_name = "aInspect";

                    if (ManagerSystem.Instance.getClick()){
                        ManagerSystem.Instance.setAnswer(cho[k].GetComponent<ChoiceScript>().type);
                        choicemade = true;
                        break;
                    }
                }
            }

            if (choicemade){
                for (int v = 0; v < cho.Length; v++){
                    cho[v].GetComponent<ChoiceScript>().destroySelf();
                }
            }
        }

        anim.Play(sprite_name);
    }
}
