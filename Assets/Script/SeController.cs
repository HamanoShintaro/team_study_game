using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{

    public class SeController : MonoBehaviour
    {

        // 宣言部
        private AudioSource seController;

        // 効果音を定義
        public AudioClip jump01, jump02, jump03, jump04, jump05, jump06;
        public AudioClip landing01, landing02, landing03, landing04, landing05, landing06;
        public AudioClip running01, running02, running03, running04, running05, running06;

        // 効果音格納用の連想配列の定義
        private Dictionary<int, AudioClip> jump;
        private Dictionary<int, AudioClip> landing;
        private Dictionary<int, AudioClip> running;

        // Start is called before the first frame update
        void Start()
        {
            // コンポーネントの取得
            seController = GetComponent<AudioSource>();

            // 各音声の連想配列格納
            jump = new Dictionary<int, AudioClip>{
                {1, jump01},
                {2, jump02},
                {3, jump03},
                {4, jump04},
                {5, jump05},
                {6, jump06},
            };
            
            landing = new Dictionary<int, AudioClip>{
                {1, landing01},
                {2, landing02},
                {3, landing03},
                {4, landing04},
                {5, landing05},
                {6, landing06},
            };
            
            running = new Dictionary<int, AudioClip>{
                {1, running01},
                {2, running02},
                {3, running03},
                {4, running04},
                {5, running05},
                {6, running06},
            };
        }

        public void playSeJump(int level) { seController.PlayOneShot(jump[level]); }

        public void playSeLanding(int level) { seController.PlayOneShot(landing[level]); }
        
        public void playSeRunning(int level) { seController.PlayOneShot(running[level]); }



        // Update is called once per frame
        void Update()
        {

        }
    }
}