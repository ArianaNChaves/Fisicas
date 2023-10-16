using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int _globalScore = 0;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
}
