using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{

    public class PlayerController : MonoBehaviour
    {

        private Image playerImage;
        private CharacterController characterController;
        private float velocity;
        private Vector3 initPosition;
        public float gravity;
        Rigidbody2D rb2d;
        public float jump;
        private float timeRunningMotion;

        // 進化段階1用のSpriteの定義
        public Sprite running00, running01, running02, running03, running04,
             running05, running06, running07, running08;
        public Sprite jump00;
        private Dictionary<int, Sprite> running;

        // ジャンプ判定用フラグ
        private bool jumpFlg;


        // Start is called before the first frame update
        void Start()
        {
            playerImage = GetComponent<Image>();
            rb2d = GetComponent<Rigidbody2D>();
            initPosition = new Vector3(30.0f, 105.0f, 0.0f);
            playerImage.transform.position = initPosition;
            jumpFlg = true;
            velocity = 0.0f;
            InitPlayer();
        }

        void InitPlayer()
        {
            //モーション用に連想配列へSpriteをセット
            running = new Dictionary<int, Sprite>{
                {0, running00}, {1, running01}, {2, running02}, {3, running03},
                {4, running04}, {5, running03}, {6, running02}, {7, running01},
                {8, running00}, {9, running05}, {10, running06}, {11, running07},
                {12, running08}, {13, running07}, {14, running06}, {15, running05}
            };
            this.StartCoroutine(this.runnningMotion());
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
            if (jumpFlg == false)
            {


                if (velocity < 0.0f)
                {
                    velocity = 0.0f;
                }
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpFlg = true;
                    //Debug.Log("ジャンプします");
                    // 落下速度をリセット
                    rb2d.velocity = Vector2.zero;
                    velocity = jump;
                    GameController.instance.voiceController.playVoiceJump(1);
                    GameController.instance.seController.playSeJump(1);
                    playerImage.sprite = jump00;
                    this.StartCoroutine(this.randingEvent());
                }
            }
            else if (jumpFlg == true)
            {
                velocity = velocity - gravity * Time.deltaTime;
                if (timeRunningMotion > 0.0f) { timeRunningMotion = 0.0f;  }

            }
            playerImage.transform.position = new Vector3(playerImage.transform.position.x, playerImage.transform.position.y + velocity * Time.deltaTime, 0.0f);
        }

        public IEnumerator randingEvent()
        {
            yield return new WaitForSeconds(0.1f);
            while (jumpFlg == true)
            {
                yield return new WaitForSeconds(0.02f);
            }
            GameController.instance.seController.playSeLanding(1);
        }

        public IEnumerator runnningMotion()
        {
            int runLevel = 0;

            while (true) {
                while (jumpFlg == false)
                {
                    playerImage.sprite = running[runLevel];
                    if (runLevel == 15) { runLevel = 0; } else { runLevel += 1; }
                    if (runLevel == 7 || runLevel == 15) {
                        GameController.instance.seController.playSeRunning(1);
                    }
                    yield return new WaitForSeconds(0.05f);
                }
                runLevel = 0;
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
}