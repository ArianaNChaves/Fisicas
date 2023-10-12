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
    //[SerializeField] private List<GameObject> pool;
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private int initialCountOfPool;
    [SerializeField] private Transform shootDirection;
    [SerializeField] private float bulletForce;
    
    private Dictionary<ObjectType, List<GameObject>> _pool;
    

    private bool _creatingObject = false;
    // Start is called before the first frame update
    void Start()
    {
        _pool = new Dictionary<ObjectType, List<GameObject>>();

        _pool[ObjectType.Bullet] = new List<GameObject>();
        _pool[ObjectType.Target] = new List<GameObject>();
        _pool[ObjectType.Score] = new List<GameObject>();
        
        
        for (int i = 0; i < initialCountOfPool; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            var target = Instantiate(targetPrefab);
            var score = Instantiate(scorePrefab);
            
            bullet.SetActive(false);
            target.SetActive(false);
            score.SetActive(false);
            
            _pool[ObjectType.Bullet].Add(bullet); 
            _pool[ObjectType.Target].Add(target);
            _pool[ObjectType.Score].Add(score);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_creatingObject)
            {
                _creatingObject = true;
                GameObject bulletToShoot = GetObjectFromPool(ObjectType.Bullet);
                Debug.Log("Update - bulletToShot: " + bulletToShoot);
                bulletToShoot.SetActive(true);
        
                bulletToShoot.transform.position = shootDirection.position;
                bulletToShoot.transform.rotation = shootDirection.rotation;
                
                bulletToShoot.GetComponent<Rigidbody>().AddForce(bulletToShoot.transform.forward * bulletForce, ForceMode.Impulse);
                
                _creatingObject = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    private GameObject GetObjectFromPool(ObjectType type)
    {
        GameObject objectFromPool = null;
      //  Rigidbody bulletRigidbody;
        
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
        //todo HACER DOS SWITCH UNO PARA EL ELSE Y EL OTRO PARA LA VERGA QUE ESTA ACA ABAJO LAP UTA MADRE uwu y ver que es el ArgumentNullException (probablemente sea algo comentado)

        switch (type)
        {
            case ObjectType.Bullet:
                objectFromPool.transform.position = shootDirection.position;
                objectFromPool.GetComponent<shootBullet>().notifyCollision = OnBulletllCollosion;
                
                return objectFromPool;
                break;
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
    
    public void OnBulletllCollosion(GameObject addBulletToPool)
    {              
        _pool[ObjectType.Bullet].Add(addBulletToPool);
    }
   
}