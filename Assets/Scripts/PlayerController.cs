using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement info")] 
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Vector2 curMoveValue;
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody rigidbody;

    [Header("CameraLook  Info")] 
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float lookSensitivity;
    private float cameraCurXRot;
    private Vector2 mouseDelta;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move( )
    {
        Vector3 dir = transform.forward * curMoveValue.y + transform.right * curMoveValue.x;
        rigidbody.velocity = dir * speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            curMoveValue = context.ReadValue<Vector2>();
        }
        
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMoveValue = Vector2.zero;
        }
    }

}
