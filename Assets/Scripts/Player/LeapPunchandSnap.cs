using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// LeapPunchandSnap
// LeapMotionでのパンチとビンタ処理
// 更新日：2022/10/06
// 更新者：角田エリック勇貴
public class LeapPunchandSnap : MonoBehaviour
{
    
    private Vector3 prevPosition;

    public GameObject Enemy;
    public GameObject Bullet;

    void Start()
    {
        prevPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.deltaTime, 0))
            return;
        // 現在位置取得
        var position = transform.position;
        // 現在速度取得
        var velocity = (position - prevPosition) / Time.deltaTime;
        // 前フレーム位置を更新
        prevPosition = position;
        // 現在速度ログ出力
        print($"velocity = {velocity.magnitude}");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(Bullet) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector3 vec = Enemy.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody>().velocity = vec;
        }
    }
}
