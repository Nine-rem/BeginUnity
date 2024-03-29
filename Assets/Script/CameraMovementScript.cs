using System;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterControllerType
{
    DommLike;
    
}
public class CameraMovementScript : MonoBehaviour
{
    public Rigidbody cameraRigidBody;
    public Transform cameraTransform;
    public float speed = 5f;
    public float rotationSpeed = 360f;
    public float jumpForce = 20f;

    public CharacterControllerType characterControllerType;
    private float zMovement = 0.0f;
    private float yawRotation = 0.0f;
    private float xMovement = 0.0f;
    private bool wantToJump = false;
    public float mouseSensitivity = .5f;

    private void Start()
    {
        Debug.Log($"Speed Dans Start : {speed}");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zMovement += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            zMovement -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            switch (CharacterControllerType)
            {
                case CharacterControllerType.DommLike :
            }
            yawRotation -= rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            yawRotation += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {


            if (Physics.SphereCast(cameraTransform.position,
                    0.48f,
                    Vector3.down,
                    out var _osef,
                    0.55f
                    ))
            {
                wantToJump = true;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var rotation = cameraTransform.rotation;
        var eulerRotation = rotation.eulerAngles;
        rotation = Quaternion.Euler(
            eulerRotation.x,
            eulerRotation.y + yawRotation,
            eulerRotation.z
        );
        cameraTransform.rotation = rotation;
        cameraTransform.position += rotation * Vector3.forward * zMovement;
        
        if (wantToJump)
        {
            cameraRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            wantToJump = false;
        }

        zMovement = 0.0f;
        yawRotation = 0.0f;
    }
}