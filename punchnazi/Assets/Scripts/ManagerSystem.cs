using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSystem : MonoBehaviour {

	public static ManagerSystem Instance { get; private set; }
    
    //Settings
    private GameObject inventory;
    private GameObject mouse_icon;
    private GameObject textbox;
    private bool load_ui;

    private int[] items;
    private string time;

    //Controls
    private bool canmove;
    private bool click;
    private string choice;

    //Instances
    public GameObject inv_pref;
    public GameObject mouse_pref;
    public GameObject textbox_pref;
    public GameObject choice_pref;
    public GameObject pickup_pref;

    //Keys
    private bool[] keys;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this.gameObject);
        }
        Cursor.visible = false;

        canmove = true;
        time = "3:41am";
        keys = new bool[15];
        for (int i = 0; i < keys.Length; i++){
            keys[i] = false;
        }
    }

    void Start() {
        createInventory();
        load_ui = false;
        choice = "Z";
        items = new int[6];
        for (int i = 0; i < items.Length; i++){
            items[i] = -1;
        }
    }

    void Update() {
        //Load UI
        if (load_ui){
            createInventory();
            load_ui = false;
        }

        //Controls
        click = false;
        click = Input.GetMouseButtonDown(0);
        if (click){
            Cursor.visible = false;
        }

        /*
        string temp = "";
        for (int i = 0; i < items.Length; i++){
            temp += "[" + i + ": " + items[i] + "] ";
        }
        Debug.Log(temp);
        */
    }

    private void createInventory() {
        if (inventory == null){
            inventory = Instantiate(inv_pref, new Vector3(0f, 0f, -45f), transform.rotation);
        }
        if (mouse_icon == null){
            Vector3 v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = -50f;
            mouse_icon = Instantiate(mouse_pref, v3, transform.rotation);
        }
    }

    public int getItem(int num){
        return items[num];
    }

    public void addItem(int num){
        for (int i = 0; i < items.Length; i++){
            if (items[i] == -1){
                items[i] = num;
                break;
            }
        }
    }

    public string getTime(){
        return time;
    }

    public void createText(string text){
        textbox = Instantiate(textbox_pref, new Vector3(0f, 0f, -25f), transform.rotation);
        textbox.GetComponent<TextBoxScript>().changeText(text);
    }

    public void textInspect(){
        if (textbox != null){
            textbox.GetComponent<TextBoxScript>().inspectText();
        }
    }

    public void createPickup(float xpos, float ypos, string new_text, int type){
        GameObject temp_pickup = Instantiate(pickup_pref, new Vector3(xpos, ypos, -25f), transform.rotation);
        temp_pickup.GetComponent<ItemPickupScript>().setText(new_text);
        temp_pickup.GetComponent<ItemPickupScript>().setType(type);
    }

    public void createChoice(string answerA, string answerB){
        choice = "Z";
        inventory.GetComponent<InventoryScript>().changeSprite("aQuestion");
        GameObject choiceA = Instantiate(choice_pref, new Vector3(0f, -2.5f, -46f), transform.rotation);
        choiceA.GetComponent<ChoiceScript>().text = answerA;
        choiceA.GetComponent<ChoiceScript>().type = "A";
        GameObject choiceB = Instantiate(choice_pref, new Vector3(0f, -3.6f, -46f), transform.rotation);
        choiceB.GetComponent<ChoiceScript>().text = answerB;
        choiceB.GetComponent<ChoiceScript>().type = "B";
    }

    public void createChoice(string answerA, string answerB, string answerC){
        choice = "Z";
        inventory.GetComponent<InventoryScript>().changeSprite("aQuestion3");
        GameObject choiceA = Instantiate(choice_pref, new Vector3(0f, -1.5f, -46f), transform.rotation);
        choiceA.GetComponent<ChoiceScript>().text = answerA;
        choiceA.GetComponent<ChoiceScript>().type = "A";
        GameObject choiceB = Instantiate(choice_pref, new Vector3(0f, -2.5f, -46f), transform.rotation);
        choiceB.GetComponent<ChoiceScript>().text = answerB;
        choiceB.GetComponent<ChoiceScript>().type = "B";
        GameObject choiceC = Instantiate(choice_pref, new Vector3(0f, -3.5f, -46f), transform.rotation);
        choiceC.GetComponent<ChoiceScript>().text = answerC;
        choiceC.GetComponent<ChoiceScript>().type = "C";
    }

    public void setAnswer(string answer){
        choice = answer;
    }

    public string getAnswer(){
        return choice;
    }

    public void finishChoice(){
        inventory.GetComponent<InventoryScript>().changeSprite("aIdle");
        inventory.GetComponent<Renderer>().enabled = false;
    }

    public bool getClick(){
        return click;
    }

    public void reloadUI(){
        load_ui = true;
    }

    public bool textboxExists(){
        bool textbox_existence = false;
        if (textbox != null){
            textbox_existence = true;
        }
        return textbox_existence;
    }

    public void setCanMove(bool new_canmove){
        canmove = new_canmove;
    }

    public bool getCanMove(){
        return canmove;
    }
}
