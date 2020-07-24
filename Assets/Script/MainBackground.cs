using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainBackground : MonoBehaviour
{
    public float speed;
    public float speedEvo1;
    public float speedEvo2;
    public float speedEvo3;
    public float startPosition;
    public float endPosition;
    public Mileage mileage;
    public GameObject Background;
    public float PositionX;
    public float PositionY;
    private Vector2 Position;

    void OnEnable()
    {
        Position.x = PositionX;
        Position.y = PositionY;
        Background.GetComponent<RectTransform>().anchoredPosition = Position;
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
            speed = speedEvo1;
        }
        else if (mileage.mileageCount >= mileage.Evo2)
        {
            speed = speedEvo2;
        }
        else if (mileage.mileageCount >= mileage.Evo3)
        {
            speed = speedEvo3;
        }
    }

    void ScrollEnd()
    {
        //通り過ぎた分を加味してポジションを再設定
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        //同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る
        //SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
