using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platformGenerator;
    private Vector2 PlatformStartPoint;
    public Player ThePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroy[] platformList;
    void Start()
    {
        PlatformStartPoint = platformGenerator.position;
        playerStartPoint = ThePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        StartCoroutine("RestartCo");
    }
    public IEnumerator RestartCo()
    {
        ThePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroy>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        ThePlayer.transform.position = playerStartPoint;
        platformGenerator.position = PlatformStartPoint;
        ThePlayer.gameObject.SetActive(true);
    }
}

