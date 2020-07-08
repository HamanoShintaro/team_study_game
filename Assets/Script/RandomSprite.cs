using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprite : MonoBehaviour
{
    //床プレハブ
    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;
    public GameObject sprite5;
    public GameObject sprite6;
    //spriteのリスト
    public List<GameObject> spriteList = new List<GameObject>();
    //リストのインデックス
    private System.Random randomIndex = new System.Random();
    //時間間隔の最小値
    public float minTime = 2f;
    //時間間隔の最大値
    public float maxTime = 5f;
    //X座標の最小値
    public float xMinPosition = -10f;
    //X座標の最大値
    public float xMaxPosition = 10f;
    //Y座標の最小値
    public float yMinPosition = 0f;
    //Y座標の最大値
    public float yMaxPosition = 10f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;
    //Mileageのデータ
    public Mileage mileage;
    //スプリットをランダムで呼び出す際のリスト最小値
    public int spriteListMinIndex;
    //スプリットをランダムで呼び出す際のリスト最大値
    public int spriteListMaxIndex;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = 9f;

        //Listに値を格納
        spriteList.Add(sprite1);
        spriteList.Add(sprite2);
        spriteList.Add(sprite3);
        spriteList.Add(sprite4);
        spriteList.Add(sprite5);
        spriteList.Add(sprite6);
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject sprite = Instantiate(spriteList[randomIndex.Next(spriteListMinIndex, spriteListMaxIndex)], transform);
            //生成した敵の位置をランダムに設定する
            sprite.transform.localPosition = GetRandomPosition();
            PenguinRun mileageSC = sprite.GetComponent<PenguinRun>();
            mileageSC.setMileage(mileage);
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }

        if (mileage.mileageCount >= mileage.Evo1)
        {
            minTime = 1.0f;
            maxTime = 1.5f;
        }
        else if (mileage.mileageCount >= mileage.Evo2)
        {
            spriteListMaxIndex = 6;
            minTime = 1.0f;
            maxTime = 2.5f;
        }
        else if (mileage.mileageCount >= mileage.Evo3)
        {
            minTime = 2.5f;
            maxTime = 3.5f;
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = UnityEngine.Random.Range(xMinPosition, xMaxPosition);
        float y = UnityEngine.Random.Range(yMinPosition, yMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x, y, 0);
    }

}
