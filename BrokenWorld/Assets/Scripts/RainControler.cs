using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainControler : MonoBehaviour
{
	public Texture2D[] frames;
	public int framesPerSecond = 10;

	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		int index = (int)((Time.time * framesPerSecond) % frames.Length);
		GetComponent<Renderer>().material.mainTexture = frames[index];
	}
}
