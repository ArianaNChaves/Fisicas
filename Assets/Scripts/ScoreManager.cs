using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    private int _globalScore;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _globalScore = 0;
    }

    private void Start()
    {
        Target.OnPoint += AddPoint;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        Target.OnPoint -= AddPoint;
    }

    private void AddPoint()
    {
        _globalScore += 1;
        Debug.Log("Score: " + _globalScore);
    }

    public int GlobalScore => _globalScore;
}
