using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private Transform shootDirection;
    [SerializeField] private float bulletForce;
    [SerializeField] private PoolController poolController;
    
    private GameObject _bullet;
    private bool _startTimer = false;
    private bool _isShooting = false;
    private bool _isTimeOut = false;
    private int _actualTime;
    // Start is called before the first frame update
    void Awake()
    {
        _actualTime = timer;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_startTimer && !_isTimeOut)
            {
                StartCoroutine(CountdownTimer());
                _startTimer = true;
            }
            if (!_isShooting)
            {
                _isShooting = true;
                _bullet = poolController.GetObjectFromPool(ObjectType.Bullet);
                _bullet.SetActive(true);
                _bullet.transform.position = shootDirection.position;
                _bullet.transform.rotation = shootDirection.rotation;
                _isShooting = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (_bullet != null)
        {
            Rigidbody bulletRigidbody = _bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = Vector3.zero;
            bulletRigidbody.angularVelocity = Vector3.zero;
            bulletRigidbody.AddForce(_bullet.transform.forward * bulletForce, ForceMode.Impulse);
            _bullet = null;
        }
    }

    private IEnumerator CountdownTimer()
    {
        
        while (_actualTime > 0)
        {
            yield return new WaitForSeconds(1);
            _actualTime--;
        }
        
        Debug.Log("Time's up!");
        _isTimeOut = true;
    }

    public int ActualTime => _actualTime;
}
