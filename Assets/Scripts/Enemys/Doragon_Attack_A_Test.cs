using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doragon_Attack_A_Test : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;

    public float ReSpawnTime;
    private float currentTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一秒経つごとに弾を発射する
        currentTime += Time.deltaTime;
        if (ReSpawnTime < currentTime)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(Bullet) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector3 vec = Player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody>().velocity = vec;
        }
    }
}
