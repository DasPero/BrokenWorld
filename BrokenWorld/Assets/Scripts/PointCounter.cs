using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
	private int nextUpdate = 1;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{

		// If the next update is reached
		if (Time.time >= nextUpdate)
		{
			nextUpdate = Mathf.FloorToInt(Time.time) + 1;
			GameObject.Find("Score").GetComponent<Text>().text = (nextUpdate - 1).ToString();
		}

	}
}
