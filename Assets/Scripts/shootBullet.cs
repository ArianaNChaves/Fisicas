using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public Action<GameObject> notifyCollision;


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Equals("Floor"))
        {
            
            
          Debug.Log("shootBullet - OnCollisionEnter - gameobject: " + gameObject);
          notifyCollision.Invoke(gameObject); 
           Debug.Log("shootBullet - OnCollisionEnter - gameobject: " + gameObject);

           gameObject.SetActive(false);    

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Equals("Window") && gameObject.activeSelf)
        {
            
            notifyCollision.Invoke(gameObject);
            gameObject.SetActive(false);    

        }
    }

    
}
