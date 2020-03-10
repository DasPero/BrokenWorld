using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonControler : MonoBehaviour
{

	public void Start()
	{
		try
		{
			Slider effects = GameObject.Find("EffectSlider").GetComponent<Slider>();
			Slider music = GameObject.Find("MusicSlider").GetComponent<Slider>();
			effects.value = FindObjectOfType<AudioManager>().GetEffectVolume();
			music.value = FindObjectOfType<AudioManager>().GetMusicVolume();
		}
		catch (NullReferenceException e) { }

	}

    public void ExitHover()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_hover");
	}

	public void ExitClick()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_click");

	#if UNITY_EDITOR
				 UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif

	}

	public void PlayHover()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_hover");
	}

	public void PlayClicked()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_click");

		FindObjectOfType<AudioManager>().Stop("menu");
		FindObjectOfType<AudioManager>().Play("ingame");

		SceneManager.LoadScene("SampleScene");
	}

	public void SettingsHover()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_hover");
	}

	public void SettingsClick()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_click");
		SceneManager.LoadScene("Settings");
	}

	public void HomeHover()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_hover");
	}

	public void HomeClick()
	{
		FindObjectOfType<AudioManager>().PlayOnce("button_click");
		SceneManager.LoadScene("Main Menu");
	}

	public void SetMusicVolume()
	{
		Slider music = GameObject.Find("MusicSlider").GetComponent<Slider>();
		FindObjectOfType<AudioManager>().MusicVolume(music.value);
	}

	public void SetEffectVolume()
	{
		Slider effects = GameObject.Find("EffectSlider").GetComponent<Slider>();
		FindObjectOfType<AudioManager>().EffectVolume(effects.value);
	}
}
