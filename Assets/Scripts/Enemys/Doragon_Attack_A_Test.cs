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
        //��b�o���Ƃɒe�𔭎˂���
        currentTime += Time.deltaTime;
        if (ReSpawnTime < currentTime)
        {
            currentTime = 0;
            //�G�̍��W��ϐ�pos�ɕۑ�
            var pos = this.gameObject.transform.position;
            //�e�̃v���n�u���쐬
            var t = Instantiate(Bullet) as GameObject;
            //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
            t.transform.position = pos;
            //�G����v���C���[�Ɍ������x�N�g��������
            //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
            Vector3 vec = Player.transform.position - pos;
            //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
            t.GetComponent<Rigidbody>().velocity = vec;
        }
    }
}
