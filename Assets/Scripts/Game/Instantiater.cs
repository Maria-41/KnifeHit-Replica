using System.Collections;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
    public static Instantiater Instance;
    void Awake() { Instance = this; }

    public GameObject knifePrefab;

    private int totalAmount;
    private int amountOfKnives;
    private bool isHitTarget;

    void Start()
    {
        isHitTarget = false;
        InstantiateKnife();
    }

    void Update()
    {
        if (isHitTarget)
        {
            InstantiateKnife();
            isHitTarget = false;
        }
    }

    public void InstantiateKnife()
    {
        UIGameController.Instance.UpdateKnivesAmountText(totalAmount - amountOfKnives);

        if (amountOfKnives == totalAmount)
            return;

        Instantiate(knifePrefab, transform.position, transform.rotation);
        amountOfKnives++;
    }

    public void SetHitTarget(bool value)
    {
        isHitTarget = value;
    }

	public void SetAmountOfKnives(int value)
	{
		amountOfKnives = value;
	}

	public void SetTotalAmountOfKnives(int value)
	{
		totalAmount = value;
	}
	public int GetTotalAmountOfKnives(){
		return totalAmount;
	}
}
