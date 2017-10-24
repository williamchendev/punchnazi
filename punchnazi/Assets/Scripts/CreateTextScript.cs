using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateTextScript : MonoBehaviour {

    private new string name;
    private string[][] data;
    private TextData text;

	void Start () {
		text = new TextData();
        name = "GuideGuy";
        write();
        text.writeData(data);
        saveFile();
	}

    private void saveFile(){
        string jsontext = JsonUtility.ToJson(text, true);
        string path = Path.Combine(Application.streamingAssetsPath, name + ".json");
        File.WriteAllText(path, jsontext);
        //UnityEditor.AssetDatabase.Refresh ();
    }

    private void write(){
        //Init Event Array
        data = new string[7][];

        //event #0
        data[0] = new string[4];

        data[0][0] = "create";
        data[0][1] = "A";
        data[0][2] = "0";
        data[0][3] = "0";

        //event #1
        data[1] = new string[3];

        data[1][0] = "talk";
        data[1][1] = "D";
        data[1][2] = "...";

        //event #2
        data[2] = new string[3];

        data[2][0] = "talk";
        data[2][1] = "A";
        data[2][2] = "Q: Hey, just so you know Antifa is that way. Just head through the gates.";

        //event #3
        data[3] = new string[3];

        data[3][0] = "talk";
        data[3][1] = "A";
        data[3][2] = "Q: You look new, have I seen you before?";

        //event #4
        data[4] = new string[7];

        data[4][0] = "choice";
        data[4][1] = "A";
        data[4][2] = "2";
        data[4][3] = "I've never met you";
        data[4][4] = "I've seen you before";
        data[4][5] = "Q: That's fine, just head up through the gates for the \n tutorial we set up newcomers like you.  Soon you'll be Bashing the Fash like a pro!";
        data[4][6] = "Q: My bad, you're probably a pro Fash-Basher. Good luck anyways.";

        //event #5
        data[5] = new string[3];

        data[5][0] = "talk";
        data[5][1] = "A";
        data[5][2] = "Q: And don't forget to have some fun...";

        //event #6
        data[6] = new string[2];

        data[6][0] = "destroy";
        data[6][1] = "A";

        /*
        //event #1
        data[1] = new string[7];

        data[1][0] = "choice";
        data[1][1] = "A";
        data[1][2] = "2";
        data[1][3] = "What?";
        data[1][4] = "Huh?";
        data[1][5] = "A";
        data[1][6] = "B";

        data[2] = new string[9];

        data[2][0] = "choice";
        data[2][1] = "A";
        data[2][2] = "3";
        data[2][3] = "What?";
        data[2][4] = "Huh?";
        data[2][5] = "Hey!";
        data[2][6] = "A";
        data[2][7] = "B";
        data[2][8] = "C";

        //event #2
        data[3] = new string[2];

        data[3][0] = "destroy";
        data[3][1] = "A";
        */
    }
	
}