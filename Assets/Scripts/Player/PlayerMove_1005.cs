using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// PlayerMove_1005
// �v���C���[�̑O�i�ړ�����
// �X�V���F2022/10/08
// �X�V�ҁF�p�c�G���b�N�E�M
// �A�^�b�`��FPlayerOBJ

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
