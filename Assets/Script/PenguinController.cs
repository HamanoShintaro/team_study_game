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
        //ジャンプ判定用フラグ
        private bool jumpFlg;

        // 走るモーション用のspriteの定義
        public Sprite jump00;
        public Sprite running01, running02, running03, running04,
             running05, running06, running07, running08, running09, running10;
        private Dictionary<int, Sprite> running;
        public Mileage mileage;

        // ジャンプモーションにかかわる変数の定義
        public int level;
        public Sprite spinImage;
        public Sprite poseImage001, poseImage002, poseImage003;
        private Dictionary<int, Sprite> poseImage;

        //3段位階における2段ジャンプの画像の設定
        public Sprite jump_level3_01, jump_level3_02, jump_level3_03, jump_level3_04, jump_level3_05, jump_level3_06, jump_level3_07, jump_level3_08;
        public Dictionary<int, Sprite> jump_level_3;

        // Start is called before the first frame update
        void OnEnable()
        {
            //animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            playerImage = GetComponent<Image>();
            jumpFlg = true;
            InitPlayer();
            poseImage = new Dictionary<int, Sprite>{
                {1, poseImage001},
                {2, poseImage002},
                {3, poseImage003}
            };
            jump_level_3 = new Dictionary<int, Sprite>{
                { 1, jump_level3_01},
                { 2, jump_level3_02},
                { 3, jump_level3_03},
                { 4, jump_level3_04},
                { 5, jump_level3_05},
                { 6, jump_level3_06},
                { 7, jump_level3_07},
                { 8, jump_level3_08}
        };

        }

        void OnTriggerEnter2D(Collider2D other)
        {
                jumpFlg = false;
                jumpCount = 0;
                GameController.instance.seController.playSeLanding(level);
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

            if (Input.touchCount > 0 && jumpCount < 2)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    flap();
                }
                
            }

        }

        void flap()
        {
            //落下速度をリセット
            rb2d.velocity = Vector2.zero;
            rb2d.velocity = new Vector2(0.0f, flapVelocity);
            jumpCount++;
            GameController.instance.voiceController.playVoiceJump(level);
            GameController.instance.seController.playSeJump(level);
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
        private float randomNum;
        public IEnumerator CharacterSpin() 
        {
            if (level < 2) { 
                //Debug.Log("キャラクターを回転させます");
                spinLoopCount = 0;
                while (spinLoopCount < 20) { 
                
                    transform.Rotate(0, 0, -18.0f);
                    yield return new WaitForSeconds(0.01f);
                    spinLoopCount++;
                }
            }

            if (level == 3) {
                spinLoopCount = 0;
                while (spinLoopCount < 8) {
                    spinLoopCount++;
                    playerImage.sprite = jump_level_3[spinLoopCount];
                    yield return new WaitForSeconds(0.02f);
                }
            }

            if (level == 4)
            {
                //回転中画像に切り替え
                playerImage.sprite = spinImage;

                //回転させる
                spinLoopCount = 0;
                while (spinLoopCount < 10)
                {

                    transform.Rotate(0, 0, -36.0f);
                    yield return new WaitForSeconds(0.01f);
                    spinLoopCount++;
                }
                //ポーズ画像に切り替える
                randomNum = Random.Range(0.0f, 3.0f);
                if (randomNum < 1.0f)
                {
                    playerImage.sprite = poseImage[1];
                }
                else if (randomNum < 2.0f)
                {
                    playerImage.sprite = poseImage[2];
                }
                else 
                { 
                    playerImage.sprite = poseImage[3]; 
                }
            }
            
        }
    }
}
