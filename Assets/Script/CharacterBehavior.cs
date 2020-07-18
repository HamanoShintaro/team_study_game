using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game { 

    public class CharacterBehavior : MonoBehaviour
    {
        //画面描写時間の設定
        public float destroyMinTime = 3.0f;
        public float destroyMaxTime = 10.0f;
        public float disapearTime = 1.0f;

        //クリックされた際の処理用
        public bool clickFlg;
        private bool oneTimeFlg;
        public Sprite clickImage;
        public AudioClip apearClip;
        public AudioClip disapearClip;
        private AudioSource audioSource;
        private Image image;
        public string animalName;
        public string moveType; //swing:ゆらゆら move:ランダム移動 walk:画像切替横移動(歩く)

        //描画する場所
        public float rangeMinX;
        public float rangeMaxX;
        public float rangeMinY;
        public float rangeMaxY;

        //ゆらゆらする速度
        public float rotationSpeed = 2.0f;
        public float rotationAcceleration = 1.0f;

        //ランダム移動の処理用
        private float moveDegree;
        private float deltaDegree;
        private string rotationInclination;

        //歩く処理用
        public Sprite walkImage1;
        public Sprite walkImage2;
        private float walkTime; 

        // Start is called before the first frame update
        private void Start()
        {
            clickFlg = false;
            oneTimeFlg = true;
            audioSource = GetComponent<AudioSource>();
            image = GetComponent<Image>();

            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    Random.Range(rangeMinX, rangeMaxX),
                    Random.Range(rangeMinY, rangeMaxY)
                );
            //moveタイプの場合初期の向きと回転方向を設定
            if (moveType == "move") {
                moveDegree = Random.Range(0f, 360f);
                transform.Rotate(0, 0, moveDegree);
                if(Random.Range(-1.0f,1.0f) >= 0)
                {
                    rotationInclination = "left";
                }
                else
                {
                    rotationInclination = "right";
                }
            }
            //walkタイプの場合の初期処理
            if (moveType == "walk")
            {
                walkTime = 0;
            }
            audioSource.PlayOneShot(apearClip);
            this.StartCoroutine(this.DestroyAfterFewSeconds());
        }

        //一定時間後にキャラクターを消去する
        private IEnumerator DestroyAfterFewSeconds()
        {
            yield return new WaitForSeconds(Random.Range(destroyMinTime, destroyMaxTime));
            if (clickFlg == false) { 
                Destroy(this.gameObject);
            }
        }

        //鳴き声をあげてキャラクターを消去する
        private IEnumerator DestroyAfterClick()
        {
            audioSource.PlayOneShot(disapearClip);
            yield return new WaitForSeconds(disapearTime);
            Destroy(this.gameObject);
            clickFlg = false;
        }

        //クリックされた際の処理
        public void OnClick()
        {
            if (oneTimeFlg) {
                oneTimeFlg = false;
                clickFlg = true;
                transform.rotation = Quaternion.identity;
                image.sprite = clickImage;
                GameController.instance.Counter[animalName]++;
                Debug.Log(GameController.instance.Counter[animalName]);
                this.StartCoroutine(this.DestroyAfterClick());
            }
        }

        // Update is called once per frame
        void Update()
        {
            //クリックされるまではゆらゆらさせる
            if (clickFlg == false) {

                if(moveType == "swing") { 
                    transform.Rotate(0, 0, this.rotationSpeed * Time.deltaTime);
            
                    if (transform.rotation.z >= 0){
                        rotationSpeed = rotationSpeed - rotationAcceleration * Time.deltaTime;
                    }
                    else {
                        rotationSpeed = rotationSpeed + rotationAcceleration * Time.deltaTime;
                    }
                }else if(moveType == "move")
                {
                    if(rotationInclination == "left") { 
                        deltaDegree = Random.Range(0.0f, 1.0f) * rotationAcceleration * Time.deltaTime;
                    }
                    else
                    {
                        deltaDegree = Random.Range(-1.0f, 0.0f) * rotationAcceleration * Time.deltaTime;
                    }
                    transform.Rotate(0, 0, deltaDegree);
                    transform.Translate(Vector3.up * Time.deltaTime * rotationSpeed);
                }else if(moveType == "walk")
                {
                    transform.Translate(Vector3.right * (-1) * Time.deltaTime * rotationSpeed);
                    walkTime += Time.deltaTime;
                    if(walkTime > 1.0f)
                    {
                        if(image.sprite == walkImage1)
                        {
                            image.sprite = walkImage2;
                        }
                        else
                        {
                            image.sprite = walkImage1;
                        }
                        audioSource.PlayOneShot(apearClip);
                        walkTime = 0.0f;
                    }
                }
            }
        }
    }

}