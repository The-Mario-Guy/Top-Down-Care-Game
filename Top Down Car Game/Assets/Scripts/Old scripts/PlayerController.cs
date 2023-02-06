using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float xRange = 5.2f;

    private float _horizontalInput;
    private float _verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
    }
    void PlayerMovement()
    {
        //Horizontal movement only
        _horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * _horizontalInput * moveSpeed * Time.deltaTime);

        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * _verticalInput * moveSpeed * Time.deltaTime);

        //Left and right bounds

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }
}
