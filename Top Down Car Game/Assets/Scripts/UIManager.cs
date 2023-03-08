using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Coin Count") != null)
        {
            Debug.Log("I found it!");
        }
        else
        {
            Debug.Log("Sorry mate, no coins 'ere!");
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
