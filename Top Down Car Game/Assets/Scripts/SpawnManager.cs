using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //array of sprites to spawn
    public GameObject[] RoadSegments;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomSegments();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateRandomSegments()
    {
      float yValue = 9.26f;
        float segmentGap = 0;
        Vector2 spawnPos = new Vector2(0, segmentGap);

        for(int i = 0; i < 6; i++)
        {
            int index = Random.Range(1, 6);
            segmentGap += yValue;
            spawnPos = new Vector2(0, segmentGap);
            Instantiate(RoadSegments[index], spawnPos, RoadSegments[index].transform.rotation);
        }
        segmentGap += yValue;
        spawnPos = new Vector2(0, segmentGap);
        Instantiate(RoadSegments[0], spawnPos, RoadSegments[0].transform.rotation);
    }
    
}
