using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PenguinController : MonoBehaviour
{
    //Animator animator;
    Rigidbody2D rb2d;
    public float flapVelocity;
    int jumpCount = 0;
    //ジャンプ判定用フラグ
    private bool jumpFlg;
    //落下判定用オブジェクトのタグ
    //string fallCheckerTag = "FallChecker";

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        jumpFlg = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (jumpFlg == true) 
        {
            //Debug.Log("何かが判定に入りました");
            jumpFlg = false;
            jumpCount = 0;
        }

        /*
        if (other.gameObject.tag == fallCheckerTag)
        {
            //相手が落下判定用オブジェクトだった時の処理
            //すぐに自分を削除
            //Destroy(this.gameObject);
        }
        */
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (jumpFlg == false)
        { 
            jumpFlg = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            flap();
        }
    }

    void flap()
    {
        //落下速度をリセット
        rb2d.velocity = Vector2.zero;
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
        jumpCount++;
    }
}
