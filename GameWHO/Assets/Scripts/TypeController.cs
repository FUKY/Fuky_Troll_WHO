﻿using UnityEngine;
using System.Collections;

public class TypeController : MonoBehaviour {

    public int inDex;
    public Controller control;
    private GamePlay gamePlay;
    private Rigidbody2D rigid;
    public float floatRigidbody;
    public int diem;
    void Awake()
    {
        control = GameObject.Find("Canvas").GetComponent<Controller>();
    }
	// Use this for initialization
	void Start () {
        
        diem = 10;
        floatRigidbody = 0.1f + (float)(control.score * 0.003f);
        gamePlay = gameObject.GetComponentInParent<GamePlay>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //rigid.gravityScale = floatRigidbody;
		float speed = 0;
		speed += floatRigidbody;
		rigid.velocity = new Vector2 (transform.position.x, speed);
        if (gamePlay == null)
        {
            Debug.Log("chua co");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //rigid.gravityScale = floatRigidbody;
	}
    public void DesTroy()
    {
        Destroy(gameObject);
    }

    public void CheckIndex(int indexButton)
    {
        if (inDex == indexButton)
        {
            gamePlay.AddScore();
            Destroy(gameObject);
			ExplosionController.Instance.ExplosionIcon(gameObject.GetComponent<RectTransform>().transform);
        }
        else
        {
            gamePlay.GameOver();
        }
    }
}
