using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace touch_game
{
    public class Evolution : MonoBehaviour
    {
        public Mileage mileage;
        public GameObject penguin1;
        public GameObject penguin2;
        public GameObject penguin3;
        public GameObject penguin4;
        public List<GameObject> PenguinList = new List<GameObject>();
        private int EvoFlg;
        private GameObject Player;

        void OnEnable()
        {
            PenguinList.Add(penguin1);
            PenguinList.Add(penguin2);
            PenguinList.Add(penguin3);
            PenguinList.Add(penguin4);
            EvoFlg = 0;
            Player = Instantiate(PenguinList[EvoFlg], transform);
            GameController.instance.bgmController.StartGameBgm(EvoFlg + 1);

        }

        // Update is called once per frame
        void Update()
        {

            if (mileage.mileageCount >= mileage.Evo1 && EvoFlg == 2)
            {
                Destroy(Player);
                EvoFlg += 1;
                Player = Instantiate(PenguinList[EvoFlg], transform);
                GameController.instance.bgmController.StartGameBgm(EvoFlg + 1);
            }
            else if (mileage.mileageCount >= mileage.Evo2 && EvoFlg == 1)
            {
                Destroy(Player);
                EvoFlg += 1;
                Player = Instantiate(PenguinList[EvoFlg], transform);
                GameController.instance.bgmController.StartGameBgm(EvoFlg + 1);
            }
            else if (mileage.mileageCount >= mileage.Evo3 && EvoFlg == 0)
            {
                Destroy(Player);
                EvoFlg += 1;
                Player = Instantiate(PenguinList[EvoFlg], transform);
                GameController.instance.bgmController.StartGameBgm(EvoFlg + 1);
            }
        }

        void OnDisable()
        {
            Destroy(Player);
        }
    }
}
