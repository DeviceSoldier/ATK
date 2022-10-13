using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// PlayerMove_1005
// プレイヤーの前進移動処理
// 更新日：2022/10/08
// 更新者：角田エリック勇貴
// アタッチ先：PlayerOBJ

public class PlayerMove_1005 : MonoBehaviour
{
    private float WalkSpeed;
    void Start()
    {
        transform.Rotate(new Vector3(0, -82, 0));
        WalkSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, WalkSpeed);
    }
}
