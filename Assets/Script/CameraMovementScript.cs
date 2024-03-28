using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform cameraTransform;

    public float speed = 5f;

    public float rotationSpeed = 360f;
    public CameraMovementScript()
    {
        Debug.Log(speed);
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cameraTransform.position += cameraTransform.rotation * Vector3.forward * (speed * Time.deltaTime) ;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cameraTransform.position += cameraTransform.rotation * Vector3.back * (speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var rotation = cameraTransform.eulerAngles;
            cameraTransform.rotation = Quaternion.Euler(
                rotation.x,
                rotation.y - rotationSpeed * Time.deltaTime,
                rotation.z
                );
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var rotation = cameraTransform.eulerAngles;
            cameraTransform.rotation = Quaternion.Euler(
                rotation.x,
                rotation.y + rotationSpeed * Time.deltaTime,
                rotation.z
            );
        }
    }
}
