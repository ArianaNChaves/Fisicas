using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int spawnNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SpawnNumber
    {
        get => spawnNumber;
        set => spawnNumber = value;
    }
}
