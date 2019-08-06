using UnityEngine;

[CreateAssetMenu(fileName = "NewTarget", menuName = "Target", order = 51)]
public class Target : ScriptableObject
{
    public TargetManager.TargetsNames type;
    public Sprite targetSprite;
    public float speed;
    public float timeOfChangeDirOrSpeed;  
    public int amountFixedKnives;
    public int amountKnives;

}
