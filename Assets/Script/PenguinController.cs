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
    public GameObject MainStage;
    public GameObject Result;
    //ジャンプ判定用フラグ
    private bool jumpFlg;

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

        if (transform.position.y > -550)
        {
            Result.SetActive(false);
            MainStage.SetActive(true);
        }
        else
        {
            Result.SetActive(true);
            MainStage.SetActive(false);
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
