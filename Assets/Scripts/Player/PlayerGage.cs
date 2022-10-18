using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGage : MonoBehaviour
{
	public Gage gage = new Gage();
	[SerializeField] private float phaseABulletDamage = 0.04f;

	private void Awake()
	{
		gage.SetMax(1.2f);
		gage.SetMin(0.8f);
		gage.SetValue(1.0f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			gage.Add(-phaseABulletDamage);
		}

	}

}
