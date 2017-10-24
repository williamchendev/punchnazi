
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPotraitScript : MonoBehaviour {

	//Settings
    private SpriteRenderer sr;

    private bool draw;
    private bool talking;
    private float y_pos;
    private float alpha;

    private float draw_sin;

	void Start () {
		sr = GetComponent<SpriteRenderer>();
        alpha = 0;
        draw_sin = 0;
        y_pos = transform.position.y;

        draw = true;
        talking = false;
	}
	
	void Update () {
		if (draw_sin < 1){
            draw_sin += 0.008f;
            if (draw_sin > 0.125f && draw_sin < 0.375){
                draw_sin += 0.01f;
            }
            if (draw_sin > 0.625f && draw_sin < 0.875){
                draw_sin += 0.009f;
            }
        }
        else {
            draw_sin = 0;
        }
        float temp_sin = ((Mathf.Sin(draw_sin * 2 * Mathf.PI) + 1.0f) / 2.0f) * 0.2f;

        if (draw){
            if (alpha < 1){
                alpha += 0.037f;
                if (alpha > 1){
                    alpha = 1;
                }
            }
        }
        else {
            alpha -= 0.037f;
            if (alpha <= 0){
                Destroy(gameObject);
            }
        }

        if (talking){
            transform.position = new Vector3(transform.position.x, y_pos - temp_sin, transform.position.z);
        }
        else {
            transform.position = new Vector3(transform.position.x, y_pos, transform.position.z);
        }

        Color tmp = sr.color;
        tmp.a = alpha;
        sr.color = tmp;
	}

    public void setTalking(bool talk){
        talking = talk;
        draw_sin = 0.95f;
    }

    public void selfDestroy(){
        draw = false;
    }

    public float getAlpha(){
        return alpha;
    }
}
