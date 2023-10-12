using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public List<GameObject> spawners;
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        spawners = new List<GameObject>();
        
        for (int i = 0; i < spawners.Count; i++)
        {
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
