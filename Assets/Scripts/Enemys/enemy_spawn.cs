using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
	public GameObject enemys;		//出現させる敵を入れておく
	public float appearNextTime;  //敵が出現するまでの時間
	private float elapsedTime;				//待ち時間

	// Use this for initialization
	void Start()
	{
		elapsedTime = 0f;
	}

	void Update()
	{
		if (elapsedTime < appearNextTime) //　時間経過前
		{
			elapsedTime += Time.deltaTime; 
		}

		else //　経過時間が経ったら
		{
			Destroy(this.gameObject);
			Instantiate(enemys, transform.position, transform.rotation);
		}
	}
}