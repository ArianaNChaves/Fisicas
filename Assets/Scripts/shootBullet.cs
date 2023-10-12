using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Action<GameObject> notifyCollision;
    [SerializeField] private float secondsToDesactivate;
    private Coroutine _desactivateCoroutine;


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
        Debug.Log("Colisión detectada con: " + collision.transform.name);
        if (collision.transform.name.Equals("Floor"))
        {
            if (_desactivateCoroutine != null)
            {
                StopCoroutine(_desactivateCoroutine);
            }
            
            Debug.Log("Iniciando corrutina para desactivar la bala");
            notifyCollision.Invoke(gameObject);
            _desactivateCoroutine = StartCoroutine(DeactivateAfterSeconds(secondsToDesactivate));
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
    
    private IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        
        Debug.Log("Desactivando la bala");

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);    
        }


    
    }
}

