using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasCountText;
    [SerializeField] private int _coinsCollected = 0;
    [SerializeField] private int _gasAmount = 10;
    
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      CoinCountText.text = _coinsCollected.ToString();
      GasCountText.text = _gasAmount.ToString();
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
    public void UpdateLevelCoinCount(int amount)
    {
        _coinsCollected += amount;
        CoinCountText.text = _coinsCollected.ToString();
    }
    public void UpdateGasAmount(int amount)
    {
        _gasAmount += amount;
        GasCountText.text = _gasAmount.ToString();
    }
}
