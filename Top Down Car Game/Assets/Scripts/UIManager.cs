using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI GlobalCoinCountText;
    void Start()
    {
        if(GameObject.Find("Coin Count") != null)
        {
         GlobalCoinCountText.text = GameManager.Instance.GetCoinCount().ToString();   
        }
        else
        {
            Debug.Log("Hey idiot, the Coin Counter doesn't exsist 'ere!");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RaceButtonPressed()
    {
        SceneManager.LoadScene("Game Mode");
    }
    public void SingleRacePressed()
    {
        SceneManager.LoadScene("Single Race");
    }
    public void CupRacePressed()
    {
        SceneManager.LoadScene("Course 1");
    }
}
