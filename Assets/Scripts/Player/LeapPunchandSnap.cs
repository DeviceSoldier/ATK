using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // ���݈ʒu�擾
        var position = transform.position;
        // ���ݑ��x�擾
        var velocity = (position - prevPosition) / Time.deltaTime;
        // �O�t���[���ʒu���X�V
        prevPosition = position;
        // ���ݑ��x���O�o��
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
            //�G�̍��W��ϐ�pos�ɕۑ�
            var pos = this.gameObject.transform.position;
            //�e�̃v���n�u���쐬
            var t = Instantiate(Bullet) as GameObject;
            //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
            t.transform.position = pos;
            //�G����v���C���[�Ɍ������x�N�g��������
            //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
            Vector3 vec = Enemy.transform.position - pos;
            //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
            
        }
    }
}
