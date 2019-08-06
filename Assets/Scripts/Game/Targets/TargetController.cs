using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private int childCount;
    void Start()
    {
        childCount = transform.childCount;
    }

    void Update()
    {
        int totalknives = Instantiater.Instance.GetTotalAmountOfKnives();
        if ((transform.childCount - childCount) == totalknives)
        {
            childCount = transform.childCount;
            LevelManager.Instance.isLevelComplete = true;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "knife" && other.gameObject.tag != "fallKnife")
        {
            Destroy(other.attachedRigidbody);
            other.transform.parent = this.transform;
            other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y - 0.5f);

            int totalknives = Instantiater.Instance.GetTotalAmountOfKnives();
            if ((transform.childCount - childCount) != totalknives)
            {   
                Instantiater.Instance.SetHitTarget(true);
            }
            
            other.gameObject.tag = "fixedKnife";
        }
    }

}
