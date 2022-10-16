using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy_move : MonoBehaviour
{
    private Rigidbody rb;　     　//リジッドボディを取得するための変数
    public float upForce = 200f;　//上方向にかける力
    public bool isJump;        　 //ジャンプ判定
    private GameObject target; 　 //追うターゲット、プレイヤーのオブジェクト
    public float speed;        　 //移動速度
    public GameObject cubeA;   　 //プレイヤーのオブジェクト
    public GameObject cubeB;   　 //このオブジェクト
    public float jumpPoint;    　 //ジャンプする距離
    public float deleteCount;     //削除するまでの時間
    public bool delete;           //削除


    void Start()
    {
        rb = GetComponent<Rigidbody>(); //リジッドボディを取得
        isJump = true;
        target = GameObject.Find("PlayerOBJ");
        delete = false;
        deleteCount = 0.0f;
    }
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 posA = target.transform.position;
        Vector3 posB = cubeB.transform.position;
        float dis = Vector3.Distance(posA, posB);

        if (isJump == true)
        {
            if (dis <= jumpPoint)
            {
                rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
                isJump = false;
            }
        }

        if (delete == true)
        {
            deleteCount += 1 * Time.deltaTime; 
        }
        
        if (deleteCount >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            delete = true;
        }
    }
}
