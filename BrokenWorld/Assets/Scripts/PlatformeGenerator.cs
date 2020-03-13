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
    private int platSelector;
    private int enemySelector;
    public GameObject[] platforms;
    public GameObject[] enemys;
    private float[] platformWidths;

    private float minHeight;

    public Transform maxHeightPoint;
    private float MaxHeight;
    public float maxHeightChange;
    private float heightChange;

    private float position_X_enemy;

    void Start()
    {
        //     platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        MaxHeight = maxHeightPoint.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Generator.position.x)
        {
            distance = Random.Range(DistanceBetweenMin, DistanceBetweenMax);



            platSelector = Random.Range(0, platforms.Length);
            enemySelector = Random.Range(0, enemys.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > MaxHeight)
            {
                heightChange = MaxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + platformWidths[platSelector] + distance, heightChange, transform.position.z);
            Instantiate(/*Platform*/ platforms[platSelector], transform.position, transform.rotation);

            position_X_enemy = Random.Range(-1.2f, 1.2f);
            if(enemySelector == 1)
            {
                transform.position = new Vector3(transform.position.x + position_X_enemy, transform.position.y + 0.6f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + position_X_enemy, transform.position.y + 0.8f, transform.position.z);
            }


            if (platSelector!=1 && platSelector!=2)
            {
                Instantiate(enemys[enemySelector], transform.position, transform.rotation);
            }
        }
    }
}
