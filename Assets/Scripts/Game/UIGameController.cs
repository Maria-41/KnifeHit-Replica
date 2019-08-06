using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public static UIGameController Instance;
    void Awake() { Instance = this; }

    public GameObject gameOverScreen;
    public Text stageText;
    public Text scoreInGame;
    public Text scoreAfterEnd;
    public Text amountOfKnives;

    public void ShowGameOverScreen(bool value)
    {
        gameOverScreen.SetActive(value);
    }

    public void UpdateStageText(int level)
    {
        stageText.text = "Stage " + (level).ToString();
    }

    public void UpdateScoreText(int score)
    {
        scoreInGame.text = score.ToString();
    }

    public void UpdateFinalScoreText(int score)
    {
        scoreAfterEnd.text = score.ToString();
    }

    public void UpdateKnivesAmountText(int amount)
    {
        amountOfKnives.text = amount.ToString();
    }

    // button event handling 
   
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnHomeButtonCLick()
    {
        SceneManager.LoadScene("Menu");
    }


}
