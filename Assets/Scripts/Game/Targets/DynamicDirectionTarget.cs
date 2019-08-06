using System.Collections;
using UnityEngine;

public class DynamicDirectionTarget : StaticTarget
{
    protected override void Start()
    {
		base.Start();
        ChangeSpeed();
    }

    public IEnumerator speedTime()
    {
        yield return new WaitForSeconds(time);
        motor = new JointMotor2D { motorSpeed = speed, maxMotorTorque = wheelJoint.motor.maxMotorTorque };
        ChangeSpeed();
    }

    public virtual void ChangeSpeed()
    {
        speed = speed * -1;
        StartCoroutine(speedTime());
    }
}
