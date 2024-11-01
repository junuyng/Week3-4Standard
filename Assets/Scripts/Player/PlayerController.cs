using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("CameraLook  Info")] [SerializeField]
    private float minXLook;

    [SerializeField] private float maxXLook;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private Transform cameraContainer;
    private float cameraCurXRot;
    private Vector2 mouseDelta;


    // Event Fields 
    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action OnPauseEvent;

    //Setting field
    private bool canLook;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canLook = true;
    }

    private void LateUpdate()
    {
        //Look은 카메라를 다루는 로직이기 때문에 LateUpdate에서 호출 Update혹은 FixedUpdate에서 호출 하면 물리 연산이 일어나기 전에 
        //카메라 위치가 갱신되는 시점이 물리연산 중에 일어나면 부자연스럽게 보일 수 있음 이를 방지하고자 LateUpdate에서 호출 
        // 물리연산이 끝난 후에는 캐릭터의 최신 위치를 기반으로 렌더링을 할 수 있기 때문에 더 자연스럽게 보일 수 있음.
        if (canLook)
            Look();
    }


    private void Look()
    {
        // 상하 회전을 다루는 부분 -> 머리를 위아래로 움직인다고 생각하면 됨
        cameraCurXRot += mouseDelta.y * lookSensitivity;
        cameraCurXRot = Mathf.Clamp(cameraCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-cameraCurXRot, 0, 0);

        //좌우 회전을 다루는 부분  -> 인간의 몸통을 돌린다고 생각하면 됨
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnMoveEvent?.Invoke(context.ReadValue<Vector2>()); //대각선으로 들어오면 정규화 했을 때 1값이 들어옴  , 정규화가 기본 세팅 값
        }

        else if (context.phase == InputActionPhase.Canceled)
        {
            OnMoveEvent?.Invoke(Vector2.zero);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ToggleCanLook();
            OnPauseEvent?.Invoke();
        }
    }

    public void ToggleCanLook()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            canLook = false;
        }

        else if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            canLook = true;
        }
    }
}