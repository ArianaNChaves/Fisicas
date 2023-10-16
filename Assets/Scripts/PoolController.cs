using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum ObjectType
{
    Bullet,
    Target,
    Score
}
public class PoolController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private Transform shootDirection;
    [SerializeField] private int initialCountOfBullet;
    [SerializeField] private int initialCountOfScore;
    [SerializeField] private int initialCountOfTarget;
    
    
    private Dictionary<ObjectType, List<GameObject>> _pool;

    // Start is called before the first frame update
    private void Start()
    {
        _pool = new Dictionary<ObjectType, List<GameObject>>();

        _pool[ObjectType.Bullet] = new List<GameObject>();
        _pool[ObjectType.Target] = new List<GameObject>();
        _pool[ObjectType.Score] = new List<GameObject>();
        
        for (int i = 0; i < initialCountOfBullet; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _pool[ObjectType.Bullet].Add(bullet); 
        }
        for (int i = 0; i < initialCountOfScore; i++)
        {
            var score = Instantiate(scorePrefab);
            score.SetActive(false);
            _pool[ObjectType.Score].Add(score);
        }
        for (int i = 0; i < initialCountOfTarget; i++)
        {
            var target = Instantiate(targetPrefab);
          //  target.GetComponent<Target>().ID = i;
            target.SetActive(false);
            _pool[ObjectType.Target].Add(target);
        }
        

    }

    // Update is called once per frame
    private void Update()
    {
       
        
    }

    private void FixedUpdate()
    {
        
    }

    public GameObject GetObjectFromPool(ObjectType type)
    {
        GameObject objectFromPool = null;
        
        if (_pool[type].Count > 0)
        {
            objectFromPool = _pool[type][0];
            _pool[type].RemoveAt(0);
        }
        else
        {
            switch (type)
            {
                case ObjectType.Bullet:
                    objectFromPool = Instantiate(bulletPrefab);
                    break;
                case ObjectType.Target:
                    objectFromPool = Instantiate(targetPrefab);
                    break;
                case ObjectType.Score:
                    objectFromPool = Instantiate(scorePrefab);
                    break;
                default:
                    Debug.LogError("GetObjectFromPool - ELSE - type error");
                    break;
            }
        }

        switch (type)
        {
            case ObjectType.Bullet:
                objectFromPool!.transform.position = shootDirection.position;
                objectFromPool.GetComponent<ShootBullet>().notifyCollision = OnBulletCollision;
                return objectFromPool;
            case ObjectType.Target:
                Debug.Log("Type.Target");
                break;
            case ObjectType.Score:
                Debug.Log("Type.Score");
                break;
            default:
                Debug.LogError("GetObjectFromPool - ObjectType error");
                break;
        }
        
        Debug.LogError("GetObjectFromPool - Si llego aca seguramente explota");
        return objectFromPool;
    }
    
    private void OnBulletCollision(GameObject addBulletToPool)
    {              
        _pool[ObjectType.Bullet].Add(addBulletToPool);
    }
   
}