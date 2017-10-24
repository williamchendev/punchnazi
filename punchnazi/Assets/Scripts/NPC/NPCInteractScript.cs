using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractScript : MonoBehaviour {

	//Settings
    private bool end;
	private int event_num;
    private string[][] text_event;

    private GameObject characterA;
    private GameObject characterB;
    private GameObject characterC;

    private bool event_pass;
    private string choice;
    private bool answered;

    //Sprites
    private Sprite NPC_A;
    private Sprite NPC_B;
    private Sprite NPC_C;
        
    void Awake () {
        end = false;
		event_num = 0;
        event_pass = false;
        answered = false;
	}
	
	void Update () {
        if (text_event == null){
            end = true;
        }

		if (end){
            ManagerSystem.Instance.setCanMove(true);
            if (characterA != null){
                Destroy(characterA.gameObject);
            }
            if (characterB != null){
                Destroy(characterB.gameObject);
            }
            if (characterC != null){
                Destroy(characterC.gameObject);
            }
            Destroy(gameObject);
        }
        else {
            if (event_num >= text_event.Length){
                if (!ManagerSystem.Instance.textboxExists()){
                    end = true;
                }
            }
            else {
                if (text_event[event_num][0] == "talk"){
                    if (event_pass){
                        if (!ManagerSystem.Instance.textboxExists()){
                            resetCharacters();
                            event_pass = false;
                            event_num++;
                        }
                    }
                    else {
                        setTalking(text_event[event_num][1]);
                        ManagerSystem.Instance.createText(text_event[event_num][2]);
                        event_pass = true;
                    }
                }
                else if (text_event[event_num][0] == "create"){
                    if (event_pass){
                        float npc_temp_alpha = 0;
                        if (text_event[event_num][1] == "A"){
                            npc_temp_alpha = characterA.GetComponent<NPCPotraitScript>().getAlpha();
                        }
                        else if (text_event[event_num][1] == "B"){
                            npc_temp_alpha = characterB.GetComponent<NPCPotraitScript>().getAlpha();
                        }
                        else if (text_event[event_num][1] == "C"){
                            npc_temp_alpha = characterC.GetComponent<NPCPotraitScript>().getAlpha();
                        }

                        if (npc_temp_alpha >= 1){
                            event_pass = false;
                            event_num++;
                        }
                    }
                    else {
                        float temp_x = float.Parse(text_event[event_num][2]);
                        float temp_y = float.Parse(text_event[event_num][3]);
                        GameObject temp_pref_npc = new GameObject("npc_portrait", typeof(SpriteRenderer), typeof(NPCPotraitScript));
                        temp_pref_npc.transform.position = new Vector3(temp_x, temp_y, -20f);
                        Color temp_npc_color = temp_pref_npc.GetComponent<SpriteRenderer>().color;
                        temp_npc_color.a = 0;
                        temp_pref_npc.GetComponent<SpriteRenderer>().color = temp_npc_color;

                        if (text_event[event_num][1] == "A"){
                            characterA = temp_pref_npc;
                            characterA.GetComponent<SpriteRenderer>().sprite = NPC_A;
                        }
                        else if (text_event[event_num][1] == "B"){
                            characterB = temp_pref_npc;
                            characterB.GetComponent<SpriteRenderer>().sprite = NPC_B;
                        }
                        else if (text_event[event_num][1] == "C"){
                            characterC = temp_pref_npc;
                            characterC.GetComponent<SpriteRenderer>().sprite = NPC_C;
                        }
                        event_pass = true;
                    }
                }
                else if (text_event[event_num][0] == "destroy"){
                    if (event_pass){
                        bool npc_destroyed = false;
                        if (text_event[event_num][1] == "A"){
                            if (characterA == null){
                                npc_destroyed = true;
                            }
                        }
                        else if (text_event[event_num][1] == "B"){
                            if (characterB == null){
                                npc_destroyed = true;
                            }
                        }
                        else if (text_event[event_num][1] == "C"){
                            if (characterC == null){
                                npc_destroyed = true;
                            }
                        }

                        if (npc_destroyed){
                            event_pass = false;
                            event_num++;
                        }
                    }
                    else {
                        if (text_event[event_num][1] == "A"){
                            characterA.GetComponent<NPCPotraitScript>().selfDestroy();
                        }
                        else if (text_event[event_num][1] == "B"){
                            characterB.GetComponent<NPCPotraitScript>().selfDestroy();
                        }
                        else if (text_event[event_num][1] == "C"){
                            characterC.GetComponent<NPCPotraitScript>().selfDestroy();
                        }
                        event_pass = true;
                    }
                }
                else if (text_event[event_num][0] == "choice"){
                    if (event_pass){
                        if (answered){
                            ManagerSystem.Instance.finishChoice();
                            setTalking(text_event[event_num][1]);
                            if (text_event[event_num][2] == "2"){
                                if (choice.Substring(0, 1) == "A"){
                                    ManagerSystem.Instance.createText(text_event[event_num][5]);
                                }
                                else if (choice.Substring(0, 1) == "B"){
                                    ManagerSystem.Instance.createText(text_event[event_num][6]);
                                }
                            }
                            else if (text_event[event_num][2] == "3"){
                                if (choice.Substring(0, 1) == "A"){
                                    ManagerSystem.Instance.createText(text_event[event_num][6]);
                                }
                                else if (choice.Substring(0, 1) == "B"){
                                    ManagerSystem.Instance.createText(text_event[event_num][7]);
                                }
                                else if (choice.Substring(0, 1) == "C"){
                                    ManagerSystem.Instance.createText(text_event[event_num][8]);
                                }
                            }
                            event_pass = false;
                        }
                        else {
                            if (ManagerSystem.Instance.getAnswer() != "Z"){
                                choice = ManagerSystem.Instance.getAnswer() + event_num;
                                answered = true;
                            }
                        }
                    }
                    else {
                        if (answered){
                            if (!ManagerSystem.Instance.textboxExists()){
                                resetCharacters();
                                answered = false;
                                event_num++;
                            }
                        }
                        else {
                            if (text_event[event_num][2] == "2"){
                                ManagerSystem.Instance.createChoice(text_event[event_num][3], text_event[event_num][4]);
                                event_pass = true;
                            }
                            else if (text_event[event_num][2] == "3"){
                                ManagerSystem.Instance.createChoice(text_event[event_num][3], text_event[event_num][4], text_event[event_num][5]);
                                event_pass = true;
                            }
                        }
                    }
                }
                else if (text_event[event_num][0] == "end"){
                    end = true;
                }
            }
        }
	}

    private void resetCharacters(){
        if (characterA != null){
            characterA.GetComponent<NPCPotraitScript>().setTalking(false);
        }
        if (characterB != null){
            characterB.GetComponent<NPCPotraitScript>().setTalking(false);
        }
        if (characterC != null){
            characterC.GetComponent<NPCPotraitScript>().setTalking(false);
        }
    }

    private void setTalking(string char_set){
        if (char_set == "A"){
            characterA.GetComponent<NPCPotraitScript>().setTalking(true);
        }
        else if (char_set == "B"){
            characterB.GetComponent<NPCPotraitScript>().setTalking(true);
        }
        else if (char_set == "C"){
            characterC.GetComponent<NPCPotraitScript>().setTalking(true);
        }
    }

    public void setNPC(int num, Sprite spr){
        if (num == 0){
            NPC_A = spr;
        }
        else if (num == 1){
            NPC_B = spr;
        }
        else if (num == 2){
            NPC_C = spr;
        }
    }

    public void setText(string[][] new_event){
        text_event = new_event;
    }
}
