using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance;

    void Awake() { Instance = this; }

    public GameObject[] targets;
    public Vector3 targetPos;
    public enum TargetsNames { StaticSpeed, DynamicDir, DynamicSpeed, Boss }

    private GameObject activeTarget;

    public void InstantiateTarget(Target targetLevel)
    {
        activeTarget = Instantiate(targets[(int)targetLevel.type], targetPos, Quaternion.identity);
        StaticTarget target = activeTarget.GetComponentInChildren<StaticTarget>();
        target.speed = targetLevel.speed;
        target.time = targetLevel.timeOfChangeDirOrSpeed;
        target.countKnives = targetLevel.amountFixedKnives;
    }

    public void DestroyCompleteTarget()
    {
        Destroy(activeTarget);
    }
}
