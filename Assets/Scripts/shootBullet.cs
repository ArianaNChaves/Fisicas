using System;
using System.Collections;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Action<GameObject> notifyCollision;
    [SerializeField] private float secondsToDeactivate;

    private Coroutine _deactivateCoroutine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            NotifyAndDeactivate(0.2f);
        }
        else if (collision.transform.CompareTag("Floor"))
        {
            if (_deactivateCoroutine != null)
            {
                StopCoroutine(_deactivateCoroutine);
            }
            
            NotifyAndDeactivate(secondsToDeactivate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Window") && gameObject.activeSelf)
        {
            NotifyAndDeactivate(0);  
        }
    }

    private void NotifyAndDeactivate(float delay)
    {
        notifyCollision?.Invoke(gameObject); 
        _deactivateCoroutine = StartCoroutine(DeactivateAfterSeconds(delay));
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