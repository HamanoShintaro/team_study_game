using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class PenguinController : MonoBehaviour
    {
        //Animator animator;
        Rigidbody2D rb2d;
        private Image playerImage;
        public float flapVelocity;
        int jumpCount = 0;
        public GameObject MainStage;
        public GameObject Result;
        //ジャンプ判定用フラグ
        private bool jumpFlg;

        // 進化段階1用のSpriteの定義
        public Sprite jump00;
        public Sprite running01, running02, running03, running04,
             running05, running06, running07, running08, running09, running10;
        private Dictionary<int, Sprite> running;

        // Start is called before the first frame update
        void Start()
        {
            //animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            playerImage = GetComponent<Image>();
            jumpFlg = true;
            InitPlayer();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
                jumpFlg = false;
                jumpCount = 0;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (jumpFlg == false)
            {
                jumpFlg = true;
            }
        }

        void InitPlayer()
        {
            //モーション用に連想配列へSpriteをセット
            running = new Dictionary<int, Sprite>{
                {0, running01}, {1, running02}, {2, running03}, {3, running04},
                {4, running05}, {5, running06}, {6, running07}, {7, running08},
                {8, running09}, {9, running10}
            };
            this.StartCoroutine(this.runnningMotion());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            {
                flap();
            }

            if (transform.position.y < -550)
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
            GameController.instance.voiceController.playVoiceJump(1);
            GameController.instance.seController.playSeJump(1);
            playerImage.sprite = jump00;

            //空中ジャンプでキャラクターを1回転させる
            if (jumpCount == 2) {
                this.StartCoroutine(this.CharacterSpin());
            }

        }

        public IEnumerator runnningMotion()
        {
            int runLevel = 0;
            
            while (true) { 
                while (jumpCount == 0)
                {
                    playerImage.sprite = running[runLevel];
                    if (runLevel == 9) { runLevel = 0; } else { runLevel += 1; }
                    if (runLevel == 5 || runLevel == 9)
                    {
                        GameController.instance.seController.playSeRunning(1);
                    }
                    yield return new WaitForSeconds(0.05f);
                }
                yield return new WaitForSeconds(0.05f);
            }          
        }

        private int spinLoopCount;
        public IEnumerator CharacterSpin() 
        {
            //Debug.Log("キャラクターを回転させます");
            spinLoopCount = 0;
            while (spinLoopCount < 20) { 
                
                transform.Rotate(0, 0, -18.0f);
                yield return new WaitForSeconds(0.01f);
                spinLoopCount++;
            }
        }
    }
}
