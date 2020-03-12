using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {
	private string question;
	private string right;
	private string wrong;

	public Question(string q, string r, string w)
	{
		question = q;
		right = r;
		wrong = w;
	}

	public Question(Question q)
	{
		question = q.question;
		right = q.right;
		wrong = q.wrong;
	}

	public string getQuestion()
	{
		return question;
	}

	public string getRight()
	{
		return right;
	}

	public string getWrong()
	{
		return wrong;
	}

	public bool isRight(string q)
	{
		return q == right;
	}
}
