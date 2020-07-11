using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class GameController : MonoBehaviour
    {

        public float LEAST_TIME = 3.0f;
        public static GameController instance;
        public Spawner Spawner;
        public StartMenu StartMenu;
        public ReadyText ReadyText;
        public Image LeastTime;
        public Background background;
        public Background background_sub;
        public GameObject resultObj;
        public Result result;
        public Dictionary<string, int> Counter;
        public GameObject pictureBookObj;
        public PictureBook pictureBook;
        public GameObject playGameObj;
        public PlayGame playGame;
        public MainStage mainStage;

        //音響用インスタンス
        public BgmController bgmController;
        public VoiceController voiceController;
        public SeController seController;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        public void Start()
        {
            //ゲーム環境の設定
            this.voiceController.resetVoice();
            this.voiceController.playVoiceTitle();
            this.bgmController.StartTitleBgm();
            this.Spawner.spawnFlg = false;
            this.StartMenu.displayFlg = true;
            this.result.displayFlg = false;
            this.resultObj.SetActive(false);
            this.pictureBookObj.SetActive(false);
            this.mainStage.gameObject.SetActive(false);
        }

        public void ClickStart()
        {
            this.bgmController.StopBgm();
            this.StartMenu.displayFlg = false;
            this.ReadyText.displayFlg = true;
            this.StartCoroutine(this.FullfillTime());
            this.StartCoroutine(this.GameStart());
            //this.playGameObj.SetActive(true);
            //this.playGame.displayFlg = true;
            this.mainStage.gameObject.SetActive(true);
        }

        public void ClickPictureBook()
        {
            this.StartMenu.displayFlg = false;
            callPictureBook();
        }

        public IEnumerator GameStart()
        {
            yield return new WaitForSeconds(ReadyText.spanTime * 5);
            this.bgmController.StartGameBgm(1);
            this.voiceController.playVoiceStart();
            this.Spawner.spawnFlg = true;

            float leastTime = LEAST_TIME;
            while (leastTime > 0)
            {
                if(leastTime < LEAST_TIME/3)
                {
                    this.bgmController.upPitch();
                    if (this.Spawner.coefficient != 0.3f)
                    {
                        this.voiceController.playVoiceHully();
                    }
                    this.Spawner.coefficient = 0.3f;
                }
                this.LeastTime.fillAmount = leastTime / LEAST_TIME;
                leastTime -= Time.deltaTime;
                yield return null;
            }
            this.voiceController.playVoiceEnd();
            this.StopGame();
        }

        public IEnumerator FullfillTime()
        {
            while(this.LeastTime.fillAmount < 1.0f) { 
                this.LeastTime.fillAmount += 0.02f;
                yield return new WaitForSeconds(0.02f);
            }
        }

        private void StopGame()
        {
            this.Spawner.spawnFlg = false;
            this.StartCoroutine(this.Spawner.DestroyAllChildren());
            this.LeastTime.fillAmount = 0f;
            callResult();
        }

        private void callResult()
        {
            Debug.Log("結果表示処理を実行します");
            this.background.scrollFlg = true;
            this.background_sub.scrollFlg = true;
            this.result.displayFlg = true;
            this.resultObj.SetActive(true);
            this.bgmController.StartTitleBgm();
        }

        private void callPictureBook()
        {
            this.background.scrollFlg = true;
            this.background_sub.scrollFlg = true;
            this.pictureBookObj.SetActive(true);
            this.pictureBook.displayFlg = true;
            this.bgmController.StartTitleBgm();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}