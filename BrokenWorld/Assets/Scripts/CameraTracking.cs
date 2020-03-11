using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
	private float length, startpos;
	public GameObject cam;
	public bool sprite;
	// Start is called before the first frame update
	void Start()
	{
		startpos = transform.position.x;

		if (sprite)
		{
			length = GetComponent<SpriteRenderer>().bounds.size.x;
		} else
		{
			length = GetComponent<RectTransform>().rect.width;
		}
	}

    // Update is called once per frame
    void Update()
    {
		float temp = cam.transform.position.x;

		transform.position = new Vector3(startpos + temp, transform.position.y, transform.position.z);

		if(startpos + length < 0)
		{
			startpos += length;
		}
    }
}
