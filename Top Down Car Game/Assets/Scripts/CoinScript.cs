using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private int value = 0;
    [SerializeField] TextMeshProUGUI coinText;
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
            Debug.Log("I've been hit!");
            value +=1;
            coinText.text = value.ToString ("0");
        
            //update the collectible count
        }
    }
}
