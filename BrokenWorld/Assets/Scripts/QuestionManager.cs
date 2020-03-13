using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
	public TextAsset textFile;
	public List<Question> vprasanja;
	public int questionCounter;
	public int choosenQuestion;
	public Question question;
	public int score;

	public void Start()
	{
		questionCounter = 1;
		score = 10;

		GameObject.Find("question").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("Answer1").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		GameObject.Find("Answer2").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		GameObject.Find("Answer1").GetComponent<Button>().interactable = false;
		GameObject.Find("Answer2").GetComponent<Button>().interactable = false;

		vprasanja = new List<Question>();

		string text = textFile.text;
		string[] splitArray = text.Split('\n');

		for (int i = 0; i < splitArray.Length; i++)
		{
			string[] vprasanje = splitArray[i].Split('@');

			string right, wrong;
			if (vprasanje[1].Contains("pravilno"))
			{
				right = vprasanje[1].Replace("(pravilno)", "");
				wrong = vprasanje[2];
			}
			else
			{
				right = vprasanje[2].Replace("(pravilno)", "");
				wrong = vprasanje[1];
			}

			vprasanja.Add(new Question(vprasanje[0], right, wrong));
		}
	}

	void Update()
	{
		if (vprasanja.Count > 0)
		{

			int s = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
			if (s != 0 && s == score)
			{
				if (!GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused)
				{
					score += 10;

					FindObjectOfType<AudioManager>().Pause("ingame");

					GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused = true;
					GameObject.Find("frame_0_delay-0.17s").GetComponent<Animator>().enabled = false;

					GameObject.Find("question").GetComponent<SpriteRenderer>().enabled = true;
					GameObject.Find("Answer1").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
					GameObject.Find("Answer2").GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
					GameObject.Find("Answer1").GetComponent<Button>().interactable = true;
					GameObject.Find("Answer2").GetComponent<Button>().interactable = true;

					GameObject.Find("Score").GetComponentInChildren<CanvasRenderer>().SetAlpha(0);

					System.Random rnd = new System.Random();
					GetComponent<QuestionManager>().choosenQuestion = rnd.Next(vprasanja.Count);

					question = new Question(vprasanja[choosenQuestion]);

					GameObject.Find("QuestionText").GetComponent<Text>().text = questionCounter + ". Question\n\n\n\n" + question.getQuestion();

					System.Random random = new System.Random();
					int temp = random.Next(2);
					if (temp == 1)
					{
						GameObject.Find("Answer1Text").GetComponent<Text>().text = question.getRight();
						GameObject.Find("Answer2Text").GetComponent<Text>().text = question.getWrong();
					}
					else
					{
						GameObject.Find("Answer1Text").GetComponent<Text>().text = question.getWrong();
						GameObject.Find("Answer2Text").GetComponent<Text>().text = question.getRight();
					}

					questionCounter++;

					if (vprasanja.Count != 1)
					{
						vprasanja.RemoveAt(choosenQuestion);
					}
				}
			}
		}
	}
}
