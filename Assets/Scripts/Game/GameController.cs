using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    void Awake() { Instance = this; }

    internal int score;
    internal bool isEndGame;

    private int recordScore;

    void Start()
    {
        isEndGame = false;

        UIGameController.Instance.ShowGameOverScreen(false);

        score = 0;
        recordScore = PlayerPrefs.GetInt("savedScore");
    }

    void Update()
    {
        if (isEndGame)
        {
            StartCoroutine(OverTime());
        }

        if (score > recordScore)
        {
            PlayerPrefs.SetInt("savedScore", Mathf.RoundToInt(score));
            PlayerPrefs.Save();
        }

        UIGameController.Instance.UpdateScoreText(score);
    }
    
    IEnumerator OverTime()
    {
        yield return new WaitForSeconds(0.8f);
        TurnOnMenu();
    }

    public void TurnOnMenu()
    {
        UIGameController.Instance.ShowGameOverScreen(true);
        UIGameController.Instance.UpdateFinalScoreText(score);
    }
}
