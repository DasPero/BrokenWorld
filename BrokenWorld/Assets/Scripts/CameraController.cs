using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Player ThePlayer;
    private Vector3 LastPlayerPosition;
    private float distanceToMove;
    void Start()
    {
        ThePlayer = FindObjectOfType<Player>();
        LastPlayerPosition = ThePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
		if (!GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused && !GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over)
		{
			distanceToMove = ThePlayer.transform.position.x - LastPlayerPosition.x;

			transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

			LastPlayerPosition = ThePlayer.transform.position;
		}
    }
}
