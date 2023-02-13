using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movefoward : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.StartGame())
        {
            LayerTwoMovement();
        }
    }

    public void LayerTwoMovement()
    {
    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
