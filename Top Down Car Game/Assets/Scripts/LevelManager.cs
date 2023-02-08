using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject PausePanel;
    public GameObject GameOverPanel;
    
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HomeButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
