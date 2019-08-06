using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    void Awake() { Instance = this; }

    public List<Target> targetLevels = new List<Target>();

    internal bool isLevelComplete;

    private int currentLevel;
    private int recordStage;

    void Start()
    {
        currentLevel = 1;

        ChangeLevel(currentLevel - 1);

        recordStage = PlayerPrefs.GetInt("savedStage");
    }

    void Update()
    {
        if (isLevelComplete)
        {
            OnLevelComplete();
        }

        if (currentLevel > recordStage)
        {
            PlayerPrefs.SetInt("savedStage", Mathf.RoundToInt(currentLevel));
            PlayerPrefs.Save();
        }

    }

    void OnLevelComplete()
    {
        TargetManager.Instance.DestroyCompleteTarget();
        currentLevel++;
        if (currentLevel > targetLevels.Count)
        {
            currentLevel = 1;
        }
        ChangeLevel(currentLevel-1);


        Instantiater.Instance.InstantiateKnife();

        UIGameController.Instance.UpdateStageText(currentLevel);
    }

    void ChangeLevel(int levelID)
    {
        TargetManager.Instance.InstantiateTarget(targetLevels[levelID]);
        Instantiater.Instance.SetTotalAmountOfKnives(targetLevels[levelID].amountKnives);
        Instantiater.Instance.SetAmountOfKnives(0);
        
        isLevelComplete = false;
    }
}
