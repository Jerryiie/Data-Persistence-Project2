using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
	public static Manager instance;

	public string currentGametag;
	public string recordGametag;
	public int recordHighscore;

	private void Awake ()
	{
		if (instance != null)
		{
			Destroy (gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad (gameObject);
		LoadData ();
	}

	public void SetGametag (string name)
	{
		currentGametag = name;
	}

	public void SetData (string gametag, int score)
	{
		recordGametag = gametag;
		recordHighscore = score;
	}

	public void SaveData ()
	{
		Data data = new Data ();
		data.gametag = recordGametag;
		data.highscore = recordHighscore;

		string savejson = JsonUtility.ToJson (data);

		File.WriteAllText (Application.persistentDataPath + "/savefile.json", savejson);
	}

	public void LoadData ()
	{
		string path = Application.persistentDataPath + "/savefile.json";

		if (File.Exists (path))
		{
			string loadjson = File.ReadAllText (path);
			Data data = JsonUtility.FromJson<Data> (loadjson);

			recordGametag = data.gametag;
			recordHighscore = data.highscore;
		}
	}
}

[System.Serializable]
class Data
{
	public string gametag;
	public int highscore;
}
