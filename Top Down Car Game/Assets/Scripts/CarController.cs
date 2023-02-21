using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //allows for the value to be edited in the inspector
    [SerializeField] private float _movespeed = 5f;

    [SerializeField] private float _boostAmount = 20f;
    [SerializeField] private float _turnspeed = 4f;
    [SerializeField] private float _xRange = 2.18f;

    [SerializeField] private bool _crossedFinishLine = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.StartGame())
        {
            CarMovement();
        }
    }

    public void CarMovement()
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
      public bool CrossedFinishLine()
    {
        return _crossedFinishLine;
    }

     private void OnCollisionEnter2D(Collision2D other) 
     {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            LevelManager.Instance.GameOver();
        }
     }
    private void OnTriggerEnter2D(Collider2D other) 
     {
        if(other.gameObject.CompareTag("Start"))
        {
          LevelManager.Instance.StartGasMeter();  
        }
        if(other.gameObject.CompareTag("FinishLine"))
        {
            _crossedFinishLine = true;
            LevelManager.Instance.Win();
        }
        if(other.gameObject.CompareTag("Boost"))
        {
            StartCoroutine(SetBoost());
        }
        if(other.gameObject.CompareTag("Oil"))
        {
            StartCoroutine(OilSpill());
        }
     }
     IEnumerator SetBoost()
     {
        float currentSpeed = _movespeed;
        _movespeed = currentSpeed + _boostAmount;
        yield return new WaitForSeconds(1f);
        _movespeed = currentSpeed;
     }
     IEnumerator OilSpill()
     {
        float currentSpeed = _movespeed;
        _movespeed = currentSpeed - 2f;
        yield return new WaitForSeconds(1f);
        _movespeed = currentSpeed;
     }
}
