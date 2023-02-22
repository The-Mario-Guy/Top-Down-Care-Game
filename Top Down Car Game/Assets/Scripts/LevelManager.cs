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
    public GameObject WinnerisYouPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasCountText;

    public Slider GasMeterSlider;
    [SerializeField] private int _coinsCollected = 0;
    //[SerializedField] allows for you to change the value in the inspector]
    //Max Gas amount vv
    [SerializeField] private int _gasAmount = 10;

    [SerializeField] private int _currentGasAmount = 10;
    public TextMeshProUGUI CountdownTimerText;

    private int _countdownTimer = 3;

    private bool _isGameActive = false;


    
    
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      StartCoroutine(StartCountdownTimer());
      CoinCountText.text = _coinsCollected.ToString();
      GasCountText.text = _gasAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool StartGame()
    {
        //_isGameActive = true;
        return _isGameActive;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
    public void Win()
    {
        Time.timeScale = 0;
        WinnerisYouPanel.SetActive(true);
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

    public void SetMaxGasFillAmount(int amount)
    {
        GasMeterSlider.maxValue = amount;
        GasMeterSlider.value = amount;
    }

    public void SetGasFillAmount(int amount) // Visable Value (Slider Value)
    {   
        if(_currentGasAmount < _gasAmount)
        {
          _currentGasAmount += amount;
          GasMeterSlider.value = _currentGasAmount;  
        } 
    }
    public void UpdateGasAmount(int amount) // Text Value 
    {
        if(_currentGasAmount < _gasAmount)
        {
        _currentGasAmount += amount;
        GasCountText.text = _currentGasAmount.ToString();
        }
        
    }

    public void StartGasMeter()
    {
        StartCoroutine(UpdateGasMeter());
    }

    IEnumerator StartCountdownTimer()
    {
        //yield = pause for X
        yield return new WaitForSeconds(0.2f);
        CountdownTimerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        //While loop
        //WARNING: Without a proper end the system WILL crash
        while(_countdownTimer > 0)
        {
            CountdownTimerText.text = _countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            _countdownTimer--; //"_countdownTimer = _countdownTime - 1;" also works the same way
        }
        CountdownTimerText.text = "GO!";
        _isGameActive = true;
        yield return new WaitForSeconds(1f);
        CountdownTimerText.gameObject.SetActive(false);
    }

    IEnumerator UpdateGasMeter()
    {
        while(_currentGasAmount > 0)
        {
            yield return new WaitForSeconds(1.4f);
            _currentGasAmount--;
            GasCountText.text = _currentGasAmount.ToString();
            GasMeterSlider.value = _currentGasAmount;
        }

        GameOver();
    }
}
