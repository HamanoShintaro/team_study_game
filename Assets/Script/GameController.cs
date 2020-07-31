﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

namespace touch_game
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        public GameObject startMenuObj;
        public GameObject pictureBookObj;
        public GameObject slideShowObj;
        public GameObject mainStageObj;
        public GameObject resultObj;
        private int slideShowFlg;

        //音響用インスタンス
        public BgmController bgmController;
        public VoiceController voiceController;
        public SeController seController;

        private void Awake()
        {
            instance = this;
            slideShowFlg = 0;
        }
        // Start is called before the first frame update

        public void Start()
        {
            //ゲーム開始の音響効果
            this.voiceController.playVoiceTitle();
            this.bgmController.StartTitleBgm();
        }

        public void StartMenuShiftMainStage()
        {
            if (slideShowFlg == 0)
            {
                slideShowFlg += 1;
                this.startMenuObj.SetActive(false);
                this.slideShowObj.SetActive(true);
            }
            else
            {
                this.startMenuObj.SetActive(false);
                this.mainStageObj.SetActive(true);
            }
            StartCoroutine(this.bgmController.fadeOutAudio());
        }

        public void StartMenuShiftPictureBook()
        {
            this.startMenuObj.SetActive(false);
            this.pictureBookObj.SetActive(true);
        }

        public void PictureBookShiftStartMenu()
        {
            this.pictureBookObj.SetActive(false);
            this.startMenuObj.SetActive(true);
        }

        public void ResultShiftStartMenu()
        {
            this.resultObj.SetActive(false);
            this.startMenuObj.SetActive(true);

            //ゲーム開始の音響効果
            this.voiceController.playVoiceTitle();
            this.bgmController.StartTitleBgm();
        }

        public void ResultShiftMainStage()
        {
            this.resultObj.SetActive(false);
            this.mainStageObj.SetActive(true);
        }

        void Update()
        {

        }

    }
}