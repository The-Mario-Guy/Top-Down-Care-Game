using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //allows for the value to be edited in the inspector
    [SerializeField] private float _movespeed = 8f;
    [SerializeField] private float _turnspeed = 8f;
    [SerializeField] private float _xRange = 2.18f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //moves car down the road (up)
        transform.Translate(Vector3.up * _movespeed * Time.deltaTime);
        transform.Translate(Vector3.right * _turnspeed * horizontalInput * Time.deltaTime);

        //Prevents the car from leaving a certain X Range
        if(transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
    }
}
