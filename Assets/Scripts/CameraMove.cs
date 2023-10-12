using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMove : MonoBehaviour
{
     
    private Quaternion _cameraRotation;
    
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

        

    }
}
