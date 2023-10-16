using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class Target : MonoBehaviour
{
    private Rigidbody _rb;
    public static event Action OnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (this.GetComponent<Rigidbody>().useGravity)
            {
                _rb.useGravity = false;
            }
            else
            {
                _rb.useGravity = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Window"))
        {
            OnPoint?.Invoke();
            gameObject.SetActive(false); 
        }
    }
}
