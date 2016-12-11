using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public string level;
	public GameObject main;
	public GameObject setting;
	public void newGame()
	{
		SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
	}
	public void resumeGame()
	{
		SceneManager.LoadScene (level, LoadSceneMode.Single);
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
