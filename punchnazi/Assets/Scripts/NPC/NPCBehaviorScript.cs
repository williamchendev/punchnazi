using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPCBehaviorScript : MonoBehaviour {

	//Settings
    public string text;

    public Sprite NPC_A;
    public Sprite NPC_B;
    public Sprite NPC_C;

    public void talk(){
        GameObject npc = new GameObject("npc_controller", typeof(NPCInteractScript));
        NPCInteractScript interact = npc.GetComponent<NPCInteractScript>();
        
        if (!string.IsNullOrEmpty(text)){
            string file_path = Path.Combine(Application.streamingAssetsPath, text + ".json");
            if (File.Exists(file_path)){
                string jsonstring = File.ReadAllText(file_path);
                TextData load = JsonUtility.FromJson<TextData>(jsonstring);
                interact.setText(load.readData());
            }
            else {
                Debug.LogError("Rip, couldn't read the data");
                Debug.LogError("File: " + text);
            }
        }
        
        //interact.setText();
        if (NPC_A != null){
            interact.setNPC(0, NPC_A);
        }
        if (NPC_B != null){
            interact.setNPC(1, NPC_B);
        }
        if (NPC_C != null){
            interact.setNPC(2, NPC_C);
        }
        ManagerSystem.Instance.setCanMove(false);
    }

}
