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
    public  float WalkSpeed;
    [SerializeField] private Transform phaseBStartPoint;
    [SerializeField] private Transform phaseCStartPoint;
    private float _t;
    private float _duration;
    
    void Start()
    {
        _duration = FindObjectOfType<PhaseManager>().phaseBTime;
        _t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_t >= _duration)
            return;
        _t += Time.deltaTime;
        transform.position = Vector3.Lerp(phaseBStartPoint.position, phaseCStartPoint.position, _t / _duration);
        //transform.position += new Vector3(0, 0, WalkSpeed)*Time.deltaTime;
    }
}
