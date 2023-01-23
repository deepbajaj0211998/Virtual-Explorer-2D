using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/Healthup")]
public class HealthBuff : PowerUpEffect
{

	public float amount;

	public override void Apply(GameObject target)
	{
		target.GetComponent<PrototypeHeroDemo>().health += amount;
	}
}
