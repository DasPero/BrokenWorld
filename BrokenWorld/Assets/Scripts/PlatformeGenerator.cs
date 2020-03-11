using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Platform;
    public Transform Generator;
    public float distance;
    private float platformWidth;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    void Start()
    {
        platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;

    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Generator.position.x)
        {
            distance = Random.Range(DistanceBetweenMin, DistanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distance, transform.position.y, transform.position.z);
            Instantiate(Platform, transform.position, transform.rotation);

        }
    }
}
