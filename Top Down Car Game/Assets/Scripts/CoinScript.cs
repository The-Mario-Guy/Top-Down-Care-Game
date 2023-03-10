using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
         if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Coin"))
            {
            LevelManager.Instance.UpdateLevelCoinCount(_value);   
            }

            if(this.gameObject.CompareTag("Gas"))
            {
            //LevelManager.Instance.UpdateGasAmount(_value);    //Comment out if it causes further issues  
            LevelManager.Instance.SetGasFillAmount(_value); //Allows the slider to be affected    
            }

            Destroy(this.gameObject);            
        }
    }
}
