using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCardScript : MonoBehaviour {

    private SpriteRenderer sr;
	private float alpha;
    private int timer;

    private GameObject black;
    private SpriteRenderer blk_sr;
    private float blk_alpha;

	void Awake () {
		sr = GetComponent<SpriteRenderer>();
        alpha = 1;
        timer = 120;
        blk_alpha = 1;

        black = new GameObject("black_screen", typeof(SpriteRenderer));
        black.transform.position = new Vector3(0f, 0f, -99f);
        blk_sr = black.GetComponent<SpriteRenderer>();
        blk_sr.sprite = sr.sprite;
        blk_sr.color = Color.black;
	}
	
	void Update () {
        if (blk_alpha <= 0.05f){
            if (timer > 0){
		        timer--;
            }
            else {
                alpha -= 0.0042f;
            }

            if (alpha <= 0.05f){
                ManagerSystem.Instance.setCanMove(true);
                Destroy(black.gameObject);
                Destroy(gameObject);
            }
        }
        else {
            blk_alpha -= 0.0035f;
            if (blk_alpha <= 0.05f){
                blk_alpha = 0;
            }
        }

        Color blktmp = blk_sr.color;
        blktmp.a = blk_alpha;
        blk_sr.color = blktmp;

        Color tmp = sr.color;
        tmp.a = alpha;
        sr.color = tmp;
	}
}
