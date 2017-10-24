using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour {

	public bool start;
    public string start_room;
    private bool scene_change;

    public GameObject manager_pref;
    public GameObject titlecard_pref;

    void Awake () {    
        scene_change = false;
        if (start){
            DontDestroyOnLoad(this);
        }
    }

    void Update() {
        if (scene_change){
            if (SceneManager.GetActiveScene().name == start_room){
                Instantiate(manager_pref, new Vector3(0f, 0f, 500f), transform.rotation);
                ManagerSystem.Instance.setCanMove(false);
                Instantiate(titlecard_pref);
                Destroy(gameObject);
            }
        }
    }

    public void button() {
        if (!scene_change){
            if (start){
                SceneManager.LoadScene(start_room);
                GetComponent<Renderer>().enabled = false;
                scene_change = true;
            }
            else {
                Application.Quit();
            }
        }
    }

}
