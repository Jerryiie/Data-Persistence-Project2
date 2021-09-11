using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
	[SerializeField] private InputField inputName;
	[SerializeField] private Text BestScoreText;

	private void Start ()
	{
		BestScoreText.text = $"Best Score : {Manager.instance.recordGametag} : {Manager.instance.recordHighscore}";
	}

	public void StartGame ()
	{
		Debug.Log (inputName.text);
		Manager.instance.SetGametag (inputName.text);
		SceneManager.LoadScene (1);
	}

	public void QuitGame ()
	{
		Manager.instance.SaveData ();

#if (UNITY_EDITOR)
		EditorApplication.ExitPlaymode ();
#else
		Application.Quit ();
#endif
	}
}
