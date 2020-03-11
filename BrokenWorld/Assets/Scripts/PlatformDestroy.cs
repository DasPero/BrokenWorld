using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public GameObject PlatformDestruction;
    // Start is called before the first frame update
    void Start()
    {
        PlatformDestruction = GameObject.Find("PlatformDestruction");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<PlatformDestruction.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
