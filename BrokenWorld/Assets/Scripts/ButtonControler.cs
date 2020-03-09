using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler : MonoBehaviour
{
    public void ExitHover()
	{

	}

	public void ExitClick()
	{
		#if UNITY_EDITOR
				 UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}

	public void PlayHover()
	{

	}

	public void PlayClicked()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void SettingsHover()
	{

	}

	public void SettingsClick()
	{
		SceneManager.LoadScene("Settings");
	}

	public void HomeHover()
	{

	}

	public void HomeClick()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
