using UnityEngine;

public class MenuController : MonoBehaviour {
	private int _recordScore;
	private int savedScore;
	private int _recordStage;
	private int savedStage;

	void Update () {
		savedScore = PlayerPrefs.GetInt("savedScore");
		if(_recordScore < savedScore)
			_recordScore = savedScore;
		
		UIMenuController.Instance.UpdateRecordScoreText(_recordScore);

		savedStage = PlayerPrefs.GetInt("savedStage");
		if(_recordStage < savedStage)
			_recordStage = savedStage;
		
		UIMenuController.Instance.UpdateRecordStageText(_recordStage);
	}

}
