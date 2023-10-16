using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform direction;
    private Quaternion _cameraRotation;
    private bool _isSeeingTarget = false;
    private GameObject _target = null;
    private Material _originalMaterial = null;
    
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        _cameraRotation = transform.rotation;
        transform.Rotate(0, mouseX ,0);
        Camera.main.transform.Rotate(-mouseY,0, 0);
        
        Ray ray = new Ray(direction.position, direction.forward);
        _isSeeingTarget = false;
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    _isSeeingTarget = true;
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (_target == null)
                    {
                        _originalMaterial = hit.collider.GetComponent<Renderer>().material;
                    }
                    Material newMaterial = new Material(_originalMaterial);
                    hit.collider.GetComponent<Renderer>().material = newMaterial;

                    if (rb != null && rb.useGravity)
                    {
                        newMaterial.color = Color.green;
                    }
                    else
                    {
                        newMaterial.color = Color.yellow;
                    }
                    _target = hit.collider.gameObject;
                }
            }
            if (!_isSeeingTarget && _target != null)
            {
                _target.GetComponent<Renderer>().material = _originalMaterial;
                _target = null;
                _originalMaterial = null;
            }
    }
    }

