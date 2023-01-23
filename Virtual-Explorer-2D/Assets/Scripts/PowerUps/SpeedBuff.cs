using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speedup")]
public class SpeedBuff : PowerUpEffect
{

	public float amount;
	public Vector3 size;

	public override void Apply(GameObject target)
	{
		target.GetComponent<PrototypeHeroDemo>().m_maxSpeed += amount;
		target.GetComponent<Transform>().localScale += size;
	}
}
