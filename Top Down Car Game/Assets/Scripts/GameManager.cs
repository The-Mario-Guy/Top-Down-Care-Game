using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int _coinCount = 0;

    [SerializeField] private float _bestDistance = 0;
    // Start is called before the first frame update
    void Awake()
    {
        //If this is here twice then destroy me, else, don't
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinCount(int amount)
    {
        _coinCount += amount;
    }

    public int GetCoinCount()
    {
        return _coinCount;
    }
    //Voids don't return values

    public void SetBestDistanceTraveled(float amount)
    {
        if(_bestDistance < amount)
        {
            _bestDistance = amount;
        }
    }
    public float GetBestDistanceTravled()
    {
        return _bestDistance;
    }
}
