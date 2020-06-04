using System.Collections;
using System.Collections.Generic;
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
        public float jump;
        private float timeRunningMotion;
        public Sprite penguinR;
        public Sprite penguinL;


        // Start is called before the first frame update
        void Start()
        {
            playerImage = GetComponent<Image>();
            initPosition = new Vector3(30.0f, 30.0f, 0.0f);
            playerImage.transform.position = initPosition;
            velocity = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {

            if (playerImage.transform.position.y <= initPosition.y)
            {
                

                if (velocity < 0.0f)
                {
                    velocity = 0.0f;
                }

                if(timeRunningMotion > 0.3f)
                {
                    timeRunningMotion = 0.0f;
                    if (playerImage.sprite == penguinL) { playerImage.sprite = penguinR; } else { playerImage.sprite = penguinL; }
                    GameController.instance.seController.playSeRunning(1);
                }else
                {
                    timeRunningMotion += Time.deltaTime;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("ジャンプします");
                    velocity = jump;
                    GameController.instance.voiceController.playVoiceJump(1);
                    GameController.instance.seController.playSeJump(1);
                    this.StartCoroutine(this.randingEvent());
                }
            }
            else if (playerImage.transform.position.y > initPosition.y)
            {
                velocity = velocity - gravity * Time.deltaTime;
                if (timeRunningMotion > 0.0f) { timeRunningMotion = 0.0f;  }

            }
            playerImage.transform.position = new Vector3(playerImage.transform.position.x, playerImage.transform.position.y + velocity * Time.deltaTime, 0.0f);
        }
        public IEnumerator randingEvent()
        {
            yield return new WaitForSeconds(0.1f);
            while (playerImage.transform.position.y > initPosition.y)
            {
                yield return new WaitForSeconds(0.02f);
            }
            GameController.instance.seController.playSeLanding(1);
        }

    }
}