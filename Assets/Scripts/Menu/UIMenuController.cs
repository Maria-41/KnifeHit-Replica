using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    public static UIMenuController Instance;
    void Awake() { Instance = this; }
    
   	public Text recordScore;
    public Text recordStage;

    public void UpdateRecordScoreText(int score)
    {
        recordScore.text = "score " + score.ToString();
    }

    public void UpdateRecordStageText(int stage)
    {
        recordStage.text = "stage " + stage.ToString();
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
}
