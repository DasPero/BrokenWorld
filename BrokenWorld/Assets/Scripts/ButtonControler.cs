using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonControler : MonoBehaviour
{

	public bool Paused;
	public bool Over;

	public void Start()
	{

		Paused = false;
		Over = false;

		try
		{
			GameObject.Find("game_paused").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("game_over").GetComponent<SpriteRenderer>().enabled = false;

			GameObject.Find("HomeButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("RestartButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("PlayButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("HomeButton").GetComponent<Button>().interactable = false;
			GameObject.Find("RestartButton").GetComponent<Button>().interactable = false;
			GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;

		}
		catch (NullReferenceException e) { }

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
		if (SceneManager.GetActiveScene().name == "Settings")
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_hover");
		}
		else
		{
			if (GameObject.Find("HomeButton").GetComponent<Button>().interactable)
			{
				FindObjectOfType<AudioManager>().PlayOnce("button_hover");
			}
		}
	}

	public void HomeClick()
	{
		if (SceneManager.GetActiveScene().name == "Settings")
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");
			SceneManager.LoadScene("Main Menu");
		}
		else
		{
			if (GameObject.Find("HomeButton").GetComponent<Button>().interactable)
			{
				FindObjectOfType<AudioManager>().PlayOnce("button_click");
				FindObjectOfType<AudioManager>().Stop("ingame");
				FindObjectOfType<AudioManager>().Play("menu");
				SceneManager.LoadScene("Main Menu");
			}
		}
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

	public void PauseHover()
	{
		if (!GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_hover");
		}
	}

	public void PauseClick()
	{
		if (!GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over && !GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");
			FindObjectOfType<AudioManager>().Pause("ingame");

			GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = false;

			GameObject.Find("game_paused").GetComponent<SpriteRenderer>().enabled = true;

			GameObject.Find("HomeButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
			GameObject.Find("RestartButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
			GameObject.Find("PlayButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
			GameObject.Find("HomeButton").GetComponent<Button>().interactable = true;
			GameObject.Find("RestartButton").GetComponent<Button>().interactable = true;
			GameObject.Find("PlayButton").GetComponent<Button>().interactable = true;

			GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused = true;
		}
	}

	public void RestartHover()
	{
		if (GameObject.Find("RestartButton").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_hover");
		}
	}

	public void RestartClick()
	{
		if (GameObject.Find("RestartButton").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");

			FindObjectOfType<AudioManager>().Stop("ingame");
			FindObjectOfType<AudioManager>().Play("ingame");

			SceneManager.LoadScene("SampleScene");
		}
	}

	public void SmallPlayHover()
	{
		if (GameObject.Find("PlayButton").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_hover");
		}
	}

	public void SmallPlayClick()
	{
		if (GameObject.Find("PlayButton").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");
			if (GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused)
			{
				Paused = false;
				GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = true;
				FindObjectOfType<AudioManager>().Play("ingame");
				GameObject.Find("game_paused").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find("HomeButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
				GameObject.Find("RestartButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
				GameObject.Find("PlayButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
				GameObject.Find("HomeButton").GetComponent<Button>().interactable = false;
				GameObject.Find("RestartButton").GetComponent<Button>().interactable = false;
				GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;
			}

			if (GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over)
			{
				FindObjectOfType<AudioManager>().Play("ingame");
				GameObject.Find("PlayButton").GetComponent<ButtonControler>().RestartClick();
				GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = true;
			}
		}
	}

	public void onAnswer1Click()
	{
		if (GameObject.Find("Answer1").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");
			FindObjectOfType<AudioManager>().Play("ingame");

			string text = GameObject.Find("Answer1Text").GetComponent<Text>().text;

			if (GameObject.Find("GameManager").GetComponent<QuestionManager>().question.isRight(text))
			{
				int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
				score += 10;
				GameObject.Find("GameManager").GetComponent<QuestionManager>().score += 10;
				GameObject.Find("Score").GetComponent<Text>().text = (score).ToString();
			}
			else
			{
				int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
				score -= 10;

				GameObject.Find("Player").GetComponent<Player>().Speed += 1;

				if (score < 0)
				{
					score = 0;
				}
				GameObject.Find("Score").GetComponent<Text>().text = (score).ToString();
			}

			GameObject.Find("question").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Answer1").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("Answer2").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("Answer1").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer2").GetComponent<Button>().interactable = false;

			GameObject.Find("Answer1Text").GetComponent<Text>().text = "";
			GameObject.Find("Answer2Text").GetComponent<Text>().text = "";
			GameObject.Find("QuestionText").GetComponent<Text>().text = "";

			GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = true;

			GameObject.Find("Score").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);

			GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused = false;

			if (GameObject.Find("GameManager").GetComponent<QuestionManager>().vprasanja.Count == 1)
			{
				GameObject.Find("GameManager").GetComponent<QuestionManager>().vprasanja.RemoveAt(0);
			}
		}
	}

	public void onAnswer2Click()
	{
		if (GameObject.Find("Answer2").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_click");
			FindObjectOfType<AudioManager>().Play("ingame");

			string text = GameObject.Find("Answer2Text").GetComponent<Text>().text;

			if (GameObject.Find("GameManager").GetComponent<QuestionManager>().question.isRight(text))
			{
				int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
				score += 10;
				GameObject.Find("GameManager").GetComponent<QuestionManager>().score += 10;
				GameObject.Find("Score").GetComponent<Text>().text = (score).ToString();
			}
			else
			{
				int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);

				GameObject.Find("Player").GetComponent<Player>().Speed += 1;

				score -= 10;
				if (score < 0)
				{
					score = 0;
				}
				GameObject.Find("Score").GetComponent<Text>().text = (score).ToString();
			}

			GameObject.Find("question").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Answer1").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("Answer2").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			GameObject.Find("Answer1").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer2").GetComponent<Button>().interactable = false;

			GameObject.Find("Answer1Text").GetComponent<Text>().text = "";
			GameObject.Find("Answer2Text").GetComponent<Text>().text = "";
			GameObject.Find("QuestionText").GetComponent<Text>().text = "";

			GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = true;

			GameObject.Find("Score").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);

			GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused = false;

			if(GameObject.Find("GameManager").GetComponent<QuestionManager>().vprasanja.Count == 1)
			{
				GameObject.Find("GameManager").GetComponent<QuestionManager>().vprasanja.RemoveAt(0);
			}
		}
	}

	public void AnswerHover()
	{
		if (GameObject.Find("Answer1").GetComponent<Button>().interactable)
		{
			FindObjectOfType<AudioManager>().PlayOnce("button_hover");
		}
	}

	public void GameOver()
	{
		FindObjectOfType<AudioManager>().Stop("ingame");
		GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over = true;
		GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = false;
		GameObject.Find("game_over").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("HomeButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		GameObject.Find("RestartButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		GameObject.Find("PlayButton").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		GameObject.Find("HomeButton").GetComponent<Button>().interactable = true;
		GameObject.Find("RestartButton").GetComponent<Button>().interactable = true;
		GameObject.Find("PlayButton").GetComponent<Button>().interactable = true;
	}
}
