using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootBullet : MonoBehaviour
{
    public Action<GameObject> notifyCollision;
    [SerializeField] private float secondsToDeactivate;
    private Coroutine _deactivateCoroutine;


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
        if (collision.transform.CompareTag("Target"))
        {
            gameObject.SetActive(false);
        }
        if (collision.transform.CompareTag("Floor"))
        {
            if (_deactivateCoroutine != null)
            {
                StopCoroutine(_deactivateCoroutine);
            }
            
            notifyCollision.Invoke(gameObject);
            
            if (gameObject.activeSelf)
            {
                _deactivateCoroutine = StartCoroutine(DeactivateAfterSeconds(secondsToDeactivate));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Window") && gameObject.activeSelf)
        {
            notifyCollision.Invoke(gameObject);
            gameObject.SetActive(false);    
        }
    }
    
    private IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);    
        }
    }
}

