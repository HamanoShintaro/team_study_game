using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{
    public class RecodePageController : MonoBehaviour
    {
        /// <summary>
        /// プレイ記録画面オブジェクト
        /// </summary>
        public GameObject Recode;

        /// <summary>
        /// プレイヤーペンギンの進化到達段階の記録画面オブジェクト
        /// </summary>
        public GameObject PenginEvolution;

        /// <summary>
        /// ゲームプレイ中に見たエピソード表示画面オブジェクト
        /// </summary>
        public GameObject Episode;

        public GameObject BackGround;

        public GameObject BackGroundSub;

        /// <summary>
        /// 記録画面の初期表示設定を行う。
        /// </summary>
        private void OnEnable()
        {
            this.Recode.SetActive(true);
            this.PenginEvolution.SetActive(false);
            this.Episode.SetActive(false);
        }

        /// <summary>
        /// 記録画面の切り替えを行う。
        /// </summary>
        /// <remarks></remarks>
        /// <param name="viewObject">
        /// 表示する記録画面のオブジェクト。プレイ記録画面、ペンギン進化記録画面、エピソード記録画面のいずれか。
        /// </param>
        public void PegeChange(GameObject viewObject)
        {
            //全ての記録画面を非表示にする
            this.Recode.SetActive(false);
            this.PenginEvolution.SetActive(false);
            this.Episode.SetActive(false);

            //背景がラインなしダイアリーの場合、
            if (this.BackGround.activeSelf == false)
            {
                this.BackGroundSub.SetActive(false);
                this.BackGround.SetActive(true);
            }

            //ペンギン画面の場合、背景をラインなしダイアリーに変更
            if (viewObject.Equals(this.PenginEvolution))
            {
                this.BackGround.SetActive(false);
                this.BackGroundSub.SetActive(true);
            }

            //引数の記録画面オブジェクトのみを表示する
            viewObject.SetActive(true);
        }
    }
}
