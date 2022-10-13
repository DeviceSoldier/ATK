using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
	public GameObject enemys;		//�o��������G�����Ă���
	public float appearNextTime;  //�G���o������܂ł̎���
	private float elapsedTime;				//�҂�����

	// Use this for initialization
	void Start()
	{
		elapsedTime = 0f;
	}

	void Update()
	{
		//�@�o�ߎ��Ԃ𑫂�
		elapsedTime += Time.deltaTime;

		//�@�o�ߎ��Ԃ��o������
		if (elapsedTime > appearNextTime)
		{
			elapsedTime = 0f;
			Instantiate(enemys, transform.position, transform.rotation);
		}
	}
}