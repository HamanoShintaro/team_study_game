﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinRun : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;
    public Mileage mileage;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームxポジションを少しずつ移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        //スクロールが目標ポイントまで達成したかをチェック
        if (transform.position.x <= endPosition) ScrollEnd();

        if (mileage.mileageCount >= mileage.Evo1)
        {
            speed = 300;
        }
        else if (mileage.mileageCount >= mileage.Evo2)
        {
            speed = 225;
        }
        else if (mileage.mileageCount >= mileage.Evo3)
        {
            speed = 150;
        }
    }

    void ScrollEnd() 
    {
        Destroy(gameObject);

        //通り過ぎた分を加味してポジションを再設定
        //float diff = transform.position.x - endPosition;
        //Vector3 restartPosition = transform.position;
        //restartPosition.x = startPosition + diff;
        //transform.position = restartPosition;

        //同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る
        //SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }

    public void setMileage(Mileage mileage)
    {
        this.mileage = mileage;
    }
}
