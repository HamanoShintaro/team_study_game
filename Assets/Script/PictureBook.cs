using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class PictureBook : MonoBehaviour
    {

        public bool displayFlg;
        public CanvasGroup pictureBook;
        public CanvasGroup pagePanel;
        public AudioSource speaker;
        public float speed;

        public Image Image;
        public Text animalName;
        public Text numberTitle;
        public Text number;

        public Sprite dogFront;
        public Sprite catFront;
        public Sprite penguinFront;
        public Sprite lionFront;
        public Sprite ladybugFront;
        public Sprite dinosaurFront;

        public Sprite dogBehind;
        public Sprite catBehind;
        public Sprite penguinBehind;
        public Sprite lionBehind;
        public Sprite ladybugBehind;
        public Sprite dinosaurBehind;
        public Sprite seacret;

        public AudioClip dogCall;
        public AudioClip catCall;
        public AudioClip penguinCall;
        public AudioClip lionCall;
        public AudioClip ladybugCall;
        public AudioClip dinosaurCall;

        private int page;
        public Dictionary<int, string> animals;
        public Dictionary<string, string> animalNames;
        public Dictionary<string, Sprite> animalFrontImages;
        public Dictionary<string, Sprite> animalBehindImages;
        public Dictionary<string, AudioClip> animalCalls;
        public Dictionary<string, bool> animalSeacretFlgs;

        private string animal;
        private int animalNum;
        private string pageTitle;
        private Sprite pageImage;
        private AudioClip pageCall;
        private string pageNumber;

        private float alpha;
        private bool oneTimeFlg;

        // Start is called before the first frame update
        void Start()
        {
            page = 0;

            //動物の定義
            animals = new Dictionary<int, string>
                {
                    {1, "dog"},
                    {2, "cat"},
                    {3, "penguin"},
                    {4, "lion"},
                    {5, "ladybug"},
                    {6, "dinosaur"},
                    {7, "return"}
                };

            animalNames = new Dictionary<string, string>
            {
                    {"dog", "いぬ"},
                    {"cat", "ねこ"},
                    {"penguin", "ペンギン"},
                    {"lion","ライオン"},
                    {"ladybug","てんとうむし"},
                    {"dinosaur","きょうりゅう"},
            };

            animalFrontImages = new Dictionary<string, Sprite>
            {
                    {"dog", dogFront},
                    {"cat", catFront},
                    {"penguin", penguinFront},
                    {"lion", lionFront},
                    {"ladybug", ladybugFront},
                    {"dinosaur", dinosaurFront}
            };

            animalBehindImages = new Dictionary<string, Sprite>
            {
                    {"dog", dogBehind},
                    {"cat", catBehind},
                    {"penguin", penguinBehind},
                    {"lion", lionBehind},
                    {"ladybug", ladybugBehind},
                    {"dinosaur", dinosaurBehind}
            };

            animalCalls = new Dictionary<string, AudioClip>
            {
                    {"dog", dogCall},
                    {"cat", catCall},
                    {"penguin", penguinCall},
                    {"lion", lionCall},
                    {"ladybug", ladybugCall},
                    {"dinosaur", dinosaurCall}
            };

            animalSeacretFlgs = new Dictionary<string, bool>
            {
                {"dog", false},
                {"cat", false},
                {"penguin", false},
                {"lion", true},
                {"ladybug", true},
                {"dinosaur", true}
            };

            oneTimeFlg = true;

            Debug.Log("動物定義完了");
        }

        // Update is called once per frame
        void Update()
        {
            //ページ変更処理
            if (displayFlg == true && oneTimeFlg == true)
            {
                oneTimeFlg = false;
                page++;
                this.StartCoroutine(this.NextPage());
            }
            //表示(子要素の描写が完了していることも確認する)
            else if (displayFlg == true && pagePanel.interactable)
            {
                if (pictureBook.alpha < 1.0f)
                {
                    pictureBook.alpha += speed * Time.deltaTime;
                }
            }
        }

        public IEnumerator NextPage()
        {
            //パネルを操作できなくする
            pagePanel.interactable = false;

            //本の中身のみフェードアウト、ただし、親要素が非表示の場合はフェードしない
            if (pictureBook.alpha == 1)
            {
                while (pagePanel.alpha > 0.0f)
                {
                    pagePanel.alpha += -1 * speed / 50;
                    yield return new WaitForSeconds(0.01f);
                }
            }

            //名前、発見数取得
            animal = animals[page];
            animalNum = PlayerPrefs.GetInt(animal);

            Debug.Log(animal);
            Debug.Log(animalNum);

            //表示内容決定処理
            //数と鳴き声はそのまま
            pageCall = animalCalls[animal];
            pageNumber = ConvertToFullWidth(animalNum.ToString()) + "ひき";

            //画像と名前はプレイデータに応じて変える
            if (animalSeacretFlgs[animal] && animalNum == 0)
            {
                pageTitle = "？？？";
                pageImage = animalBehindImages[animal];
            }
            else if (PlayerPrefs.GetInt(animal) == 0)
            {
                pageTitle = animalNames[animal];
                pageImage = animalBehindImages[animal];
            }
            else
            {
                pageTitle = animalNames[animal];
                pageImage = animalFrontImages[animal];
            }

            Debug.Log(pageTitle);
            Debug.Log(pageImage);

            //各要素に設定する
            animalName.text = pageTitle;
            Image.sprite = pageImage;
            speaker.clip = pageCall;
            number.text = pageNumber;

            //本の中身をフェードイン、ただし、親要素が非表示の場合はフェードしない
            if(pictureBook.alpha == 1.0f) { 
                while (pagePanel.alpha < 1.0f)
                {
                    pagePanel.alpha += speed / 50;
                    yield return new WaitForSeconds(0.01f);
                }
            }

            //操作可能にする
            pagePanel.interactable = true;
            if (animalSeacretFlgs[animal] == false || animalNum != 0) { 
                GameController.instance.voiceController.playVoiceAnimals(animal);
            }
            yield return null;
        }

        public void restartClick()
        {
            pictureBook.alpha = 0.0f;
            displayFlg = false;
            oneTimeFlg = true;
            page = 0;
            GameController.instance.Start();
        }

        public void onClickNext() {

            if(animals[page + 1] == "return") {
                page = 0;
            }
            oneTimeFlg = true;
        }

        public void onClickSpeaker()
        {
            speaker.Play();
        }

        static public string ConvertToFullWidth(string halfWidthStr)
        {
            const int ConvertionConstant = 65248;
            string fullWidthStr = null;

            for (int i = 0; i < halfWidthStr.Length; i++)
            {
                fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
            }

            return fullWidthStr;
        }
    }
}