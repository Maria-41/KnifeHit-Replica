using UnityEngine;

public class DynamicSpeedTarget : DynamicDirectionTarget {
	public override void ChangeSpeed()
	{
		speed = Random.Range(-250, 250);
		StartCoroutine(speedTime());
	}
}
