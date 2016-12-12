using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	private int playerPoints ;
	public GameObject main;
	public GameObject setting;
	public void newGame()
	{
		PlayerPrefs.SetInt("playerPoints", 0);
		PlayerPrefs.SetInt("level", 1);
		SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
	}
	public void resumeGame()
	{
		//playerPoints = PlayerPrefs.GetInt ("playerPoints");
		SceneManager.LoadScene ("Level"+PlayerPrefs.GetInt ("level"), LoadSceneMode.Single);
	}
	public void settings()
	{
		this.gameObject.SetActive (false);
		setting.SetActive (true);
	}
	public void ToMainMenu()
	{
		this.gameObject.SetActive (false);
		main.SetActive (true);
	}
	public void soundToggle()
	{
		if (AudioListener.pause == false) {
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		}
	}
	public void exit()
	{
		Application.Quit ();
	}
	// Use this for initialization
	void Start () {
		setting.SetActive (false);
	}
}
