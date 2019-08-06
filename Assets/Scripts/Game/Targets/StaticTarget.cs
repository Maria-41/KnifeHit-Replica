using UnityEngine;

public class StaticTarget : MonoBehaviour
{
	public float speed;
    public float time = 0;
	public int countKnives = 1;
   
    protected JointMotor2D motor;
    protected WheelJoint2D wheelJoint;
    private Vector2 position;
    private float angle;
    private float positionOffset = 1.5f;
    private float rotationOffset = 90;
    private GameObject knifePrefab;

    void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        knifePrefab  = Resources.Load<GameObject>("WoodKnife");
    }

    protected virtual void Start()
    {
        InstantiateKnives();
        motor = new JointMotor2D { motorSpeed = speed, maxMotorTorque = wheelJoint.motor.maxMotorTorque };

    }

    void FixedUpdate()
    {
        wheelJoint.useMotor = true;
        wheelJoint.motor = motor;
    }

    public void InstantiateKnives()
    {
        for (int i = 0; i < countKnives; i++)
        {
            angle = Random.Range(0, 360);

            GameObject knife = Instantiate(knifePrefab, transform.position, transform.rotation);
            knife.transform.parent = this.transform;

            position = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad) * positionOffset, Mathf.Cos(angle * Mathf.Deg2Rad) * positionOffset);
            knife.transform.localPosition = position;

            Vector3 dir = (knife.transform.position - transform.position).normalized;

            float knifeAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + rotationOffset;

            knife.transform.eulerAngles = new Vector3(0, 0, knifeAngle);


            Collider[] hitColliders = Physics.OverlapSphere(knife.transform.position, 1);
            if (hitColliders.Length > 0)
            {
                Destroy(knife);
            }
        }
    }
}
