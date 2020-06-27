using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{

    //Animator animator;
    Rigidbody2D rb2d;
    public float flapVelocity;
    // ジャンプ判定用フラグ
    private bool jumpFlg;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (jumpFlg == true) 
        {
            //Debug.Log("何かが判定に入りました");
            jumpFlg = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (jumpFlg == false) 
        {
            //Debug.Log("何かが判定をでました");
            jumpFlg = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void Flap()
    {
        //Debug.Log("ジャンプします");
        // 落下速度をリセット
        rb2d.velocity = Vector2.zero;
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }
}
