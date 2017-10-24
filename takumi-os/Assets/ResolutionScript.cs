using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResolutionScript : MonoBehaviour {

    //Settings
    private int scale;
    private int screen_width;
    private int screen_height;
    private bool fullscreen;

    private string path;

    void Awake(){
        screen_width = 480;
        screen_height = 270;
        scale = 1;

        path = "settings.txt";

        if (File.Exists(path))
        {
            string line = "";
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            scale = System.Int32.Parse(line);
            line = sr.ReadLine();
            int fullscreen_integer = System.Int32.Parse(line);
            if (fullscreen_integer == 0)
            {
                fullscreen = false;
            }
            else
            {
                fullscreen = true;
            }

            sr.Close();
        }
        else
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine("1"); //Scale
            sw.WriteLine("0"); //Fullscreen

            sw.Close();
        }

        resetResolution();
    }

    private void setScale(int new_scale){
        scale = new_scale;
        resetResolution();
        writeFile(scale, fullscreen);
    }

    private void setFullscreen(bool new_fullscreen){
        fullscreen = new_fullscreen;
        resetResolution();
        writeFile(scale, fullscreen);
    }

    private void writeFile(int new_scale, bool fullscreen){
        string[] lines = new string[2];
        lines[0] = "" + new_scale;
        if (fullscreen)
        {
            lines[1] = "1";
        }
        else
        {
            lines[1] = "0";
        }
        File.WriteAllLines(path, lines);
    }

    private void resetResolution(){
        Screen.SetResolution(screen_width * scale, screen_height * scale, fullscreen);
    }
}
